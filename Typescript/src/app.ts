import Collatz from './collatz';
import prompt_sync from 'prompt-sync';

// Display welcome message.
console.log('Welcome to the Collatz Conjecture Sequence Generator!');

// Initialize variable for reading input from console.
const prompt = prompt_sync();
// Initialize variable for keeping track of if the program is running.
let quit_program = false;
// Start program loop until the user quits.
while (!quit_program)
{
    // Prompt the user for input.
    console.log('');
    const user_input = prompt('Enter a positive integer (enter q to quit) => ');

    // Check if user wants to quit the program.
    quit_program = [ 'q', 'quit' ].some(element => user_input.toLowerCase() === element);
    if (quit_program)
    {
        continue;
    }

    // Attempt to parse the input as BigInteger.
    let user_number = BigInt(0);
    try {
        user_number = BigInt(user_input);
    } catch {
    // Prompt user for input again.
        console.log('\nNot a valid positive integer. Try again.');
        continue;
    }
    // Check if user entered a valid number.
    if (user_number <= 0) {
    // Prompt user for input again.
        console.log('\nNot a valid positive integer. Try again.');
        continue;
    }

    // Instantiate new Collatz instance, passing in user number.
    const collatz_sequence = new Collatz(user_number);
    // Print out the Collatz Sequence.
    console.log(collatz_sequence.display_sequence());
    console.log('Sequence Length: ' + collatz_sequence.get_sequence_length());
}

// Display goodbye message.
console.log('\nGoodbye!');
