"""Collatz Conjecture Sequence Generator"""
from Collatz import Collatz


def main():
    """Main function with the loop, function calls and program flow logic."""
    # Display welcome message.
    print('Welcome to the Collatz Conjecture Sequence Generator!')

    # Initialize variable for keeping track of if the program is running.
    quit_program = False
    # Start program loop until the user quits.
    while not quit_program:
        # Prompt the user for input.
        user_input = input('\nEnter a positive integer (enter q to quit) => ').casefold()

        # Check if user wants to quit the program.
        quit_program = user_input in ('q', 'quit')
        if quit_program:
            continue

        try:
            # Attempt to parse  the input as BigInteger.
            user_number = int(user_input)
            if user_number <= 0:
                raise ValueError()
        except ValueError:
            # Prompt user for input again.
            print('\nNot a valid positive integer. Try again.')
            continue

        # Instantiate new Collatz instance, passing in user number.
        collatz_sequence = Collatz(user_number)
        # Print out the Collatz Sequence.
        print(collatz_sequence.display_sequence())

    # Display goodbye message.
    print('\nGoodbye!')


# Program entry point.
if __name__ == '__main__':
    main()
