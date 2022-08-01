"""Collatz Module"""


class Collatz:
    """Collatz class for generating a Collatz Sequence from a starting value."""

    def __init__(self, starting_number):
        if starting_number <= 0:
            raise ValueError('The starting number must be a positive integer.')
        self.__starting_number = starting_number
        self.__generate_sequence()

    def get_starting_number(self):
        """The getter for __starting_number"""
        return self.__starting_number

    def set_starting_number(self, starting_number):
        """The setter for the starting_number of the Collatz Sequence. When a new starting number is
         set, the Collatz Sequence is automatically generated for that number. The starting value
         must be a positive integer."""
        if starting_number <= 0:
            raise ValueError('The starting number must be a positive integer.')
        self.__starting_number = starting_number
        self.__generate_sequence()

    def get_collatz_sequence(self):
        """Returns tuple copy of __collatz_sequence."""
        return tuple(self.__collatz_sequence)

    def __generate_sequence(self):
        """Generates and sets value for __collatz_sequence."""
        current_number = self.__starting_number
        # Initialize a new list with the user number as the first element.
        sequence = [current_number]

        # Loop until the sequence reaches the end value of one.
        while current_number > 1:
            # If even, divide the number by 2.
            # If odd, multiply the number by 3, add 1, and divide by 2.
            current_number = current_number // 2 if current_number % 2 == 0 \
                else (3 * current_number + 1) // 2
            # Add the new number to the sequence list.
            sequence.append(int(current_number))

        # Set the Collatz Sequence.
        self.__collatz_sequence = sequence

    def get_sequence_length(self):
        """Returns the length of the sequence as an integer."""
        return len(self.__collatz_sequence)

    def display_sequence(self):
        """ Builds a string with all the values in <code>collatzSequence</code>, with each value on
         its own line."""
        return '\n'.join(str(number) for number in self.__collatz_sequence)
