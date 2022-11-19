/**
 * Collatz class for generating a Collatz Sequence from a starting value.
 */
export default class Collatz {
    private starting_number: bigint;
    private collatz_sequence: Array<bigint>;

    /**
     * The constructor for the Collatz class. Sets starting_number to the passed
     * value and sets the Collatz Sequence for that number. The starting value
     * must be a positive integer.
     *
     * @param starting_number the starting number of the Collatz Sequence.
     * @throws if the starting number less than or equal to zero is passed.
     */
    public constructor(starting_number: bigint) {
        if (starting_number <= BigInt(0)) {
            throw new Error('The starting number must be a positive integer.');
        } else {
            this.starting_number = starting_number;
            this.collatz_sequence = this.generate_sequence();
        }
    }

    /**
     * The getter for starting_number.
     *
     * @return the starting number.
     */
    public get_starting_number(): bigint {
        return this.starting_number;
    }

    /**
     * The setter for the startingNumber of the Collatz Sequence.  When a new
     * starting number is set, the Collatz Sequence is automatically generated
     * for that number. The starting value must be a positive integer.
     *
     * @param starting_number the starting number of the Collatz Sequence.
     * @throws if the starting number less than or equal to zero is passed.
     */
    public set_starting_number(starting_number: bigint): void {
        if (starting_number <= BigInt(0)) {
            throw new Error('The starting number must be a positive integer.');
        } else {
            this.starting_number = starting_number;
            this.collatz_sequence = this.generate_sequence();
        }
    }

    /**
     * The getter for collatz_sequence.
     *
     * @return a readonly array.
     */
    public get_collatz_sequence(): readonly bigint[] {
        return Object.freeze(this.collatz_sequence);
    }

    /**
     * Returns the length of the sequence.
     *
     * @return the integer value of the length of the sequence.
     */
    public get_sequence_length(): number {
        return this.collatz_sequence.length;
    }

    /**
     * Builds a string with all the values in collatz_sequence, with each
     * value on its own line.
     *
     * @return a string of the Collatz Sequence.
     */
    public display_sequence(): string {
        return this.collatz_sequence.join('\n');
    }

    /**
     * Generates the Collatz Sequence from the starting number.
     *
     * @return a bigint array of the sequence.
     */
    private generate_sequence(): Array<bigint> {
        // Initialize current_number with the user number.
        let current_number: bigint = this.starting_number;
        // Initialize a new list with the user number as the first element.
        const sequence: Array<bigint> = [ current_number ];

        // Loop until the sequence reaches the end value of one.
        while (current_number !== BigInt(1)) {
            // If even, divide the number by 2.
            // If odd, multiply the number by 3, add 1, and divide by 2.
            current_number = current_number % BigInt(2) === BigInt(0) ?
                current_number / BigInt(2) :
                current_number * BigInt(3) + BigInt(1);
            // Add the new number to the sequence list.
            sequence.push(current_number);
        }

        // Set the Collatz Sequence.
        return sequence;
    }
}
