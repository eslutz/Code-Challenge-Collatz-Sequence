"""Collatz Tests Module"""
import unittest

from collatz import Collatz
from parameterized import parameterized


class CollatzTests(unittest.TestCase):
    """Test cases for Collatz module."""
    @parameterized.expand([(5, 5),
                           (50, 18),
                           (5000, 23),
                           (5000000, 98),
                           (5000000000, 89),
                           (5000000000000000000000000000000000000, 448)])
    def test_collatz_constructor_with_valid_numbers(self, starting_number, expected_count):
        """Tests constructor creates sequence of the expected length."""
        test_sequence = Collatz(starting_number)
        self.assertEqual(expected_count, test_sequence.get_sequence_length())

    @parameterized.expand([(0, "The starting number must be a positive integer."),
                           (-5, "The starting number must be a positive integer.")])
    def test_collatz_constructor_with_invalid_numbers(self, starting_number, expected_message):
        """Tests constructor throws exception with invalid input."""
        with self.assertRaises(ValueError) as ex:
            Collatz(starting_number)
        self.assertEqual(expected_message, str(ex.exception))

    @parameterized.expand([(1, 5),
                           (1, 50),
                           (1, 5000),
                           (1, 5000000),
                           (1, 5000000000),
                           (1, 5000000000000000000000000000000000000)])
    def test_collatz_setter_with_valid_numbers(self, starting_number, new_starting_number):
        """Tests starting number setter correctly sets the starting number."""
        test_sequence = Collatz(starting_number)
        test_sequence.set_starting_number(new_starting_number)
        self.assertEqual(new_starting_number, test_sequence.get_starting_number())

    @parameterized.expand([(0, "The starting number must be a positive integer."),
                           (-5, "The starting number must be a positive integer.")])
    def test_collatz_setter_with_invalid_numbers(self, new_starting_number, expected_message):
        """Tests starting number setter throws exception with invalid input."""
        test_sequence = Collatz(1)
        with self.assertRaises(ValueError) as ex:
            test_sequence.set_starting_number(new_starting_number)
        self.assertEqual(expected_message, str(ex.exception))

    def test_display_sequence(self):
        """Tests display sequence gives correct output."""
        expected_string = "5\n8\n4\n2\n1"
        test_sequence = Collatz(5)
        returned_string = test_sequence.display_sequence()
        self.assertEqual(expected_string, returned_string)


if __name__ == '__main__':
    unittest.main()
