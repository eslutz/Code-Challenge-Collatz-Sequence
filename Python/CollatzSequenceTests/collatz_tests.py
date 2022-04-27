import unittest

from collatz import Collatz
from parameterized import parameterized


class CollatzTests(unittest.TestCase):
    @parameterized.expand([(5, 5), (5000000000000000000000000000000000000, 448)])
    def test_collatz_constructor_with_valid_numbers(self, starting_number, expected_count):
        test_sequence = Collatz(starting_number)
        self.assertEqual(expected_count, len(test_sequence.get_collatz_sequence()))

    @parameterized.expand([(0, "The starting number must be a positive integer."),
                           (-5, "The starting number must be a positive integer.")])
    def test_collatz_constructor_with_invalid_numbers(self, starting_number, expected_message):
        with self.assertRaises(ValueError) as cm:
            Collatz(starting_number)
        self.assertEqual(expected_message, str(cm.exception))

    @parameterized.expand([(1, 5), (1, 50), (1, 5000000000000000000000000000000000000)])
    def test_collatz_setter_with_valid_numbers(self, starting_number, new_starting_number):
        test_sequence = Collatz(starting_number)
        test_sequence.set_starting_number(new_starting_number)
        self.assertEqual(new_starting_number, test_sequence.get_starting_number())

    @parameterized.expand([(0, "The starting number must be a positive integer."),
                           (-5, "The starting number must be a positive integer.")])
    def test_collatz_setter_with_invalid_numbers(self, new_starting_number, expected_message):
        test_sequence = Collatz(1)
        with self.assertRaises(ValueError) as cm:
            test_sequence.set_starting_number(new_starting_number)
        self.assertEqual(expected_message, str(cm.exception))

    def test_display_sequence(self):
        expected_string = "5\n8\n4\n2\n1"
        test_sequence = Collatz(5)
        returned_string = test_sequence.display_sequence()
        self.assertEqual(expected_string, returned_string)


if __name__ == '__main__':
    unittest.main()
