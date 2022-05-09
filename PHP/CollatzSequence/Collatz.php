<?php

use phpseclib3\Math\BigInteger;

class Collatz
{
    private BigInteger $startingNumber;
    private readonly array $collatzSequence;

    /**
     * The constructor for the Collatz class. Sets startingNumber to the passed value and sets
     * the Collatz Sequence for that number. The starting value must be a positive integer.
     *
     * @param BigInteger $startingNumber the starting number of the Collatz Sequence.
     * @throws InvalidArgumentException if the starting number is less than or equal to zero.
     */
    function __construct(BigInteger $startingNumber) {
        if ($startingNumber <= 0) {
            throw new InvalidArgumentException("The starting number must be a positive integer.");
        } else {
            $this->startingNumber = $startingNumber;
            $this->generateSequence();
        }
    }

    /**
     * Getter for Collatz properties.
     *
     * @throws Exception if not a valid Collatz property.
     */
    public function __get($field)
    {
        return match ($field) {
            'startingNumber' => $this->startingNumber,
            'collatzSequence' => $this->collatzSequence,
            default => throw new Exception('Invalid property: ' . $field),
        };
    }

    /**
     * The setter for the startingNumber of the Collatz Sequence.  When a new
     * starting number is set, the Collatz Sequence is automatically generated
     * for that number. The starting value must be a positive integer.
     *
     * @param BigInteger $startingNumber the starting number of the Collatz Sequence.
     * @throws InvalidArgumentException if the starting number is less than or equal to zero.
     */
    public function setStartingNumber(BigInteger $startingNumber): void
    {
        if ($startingNumber <= 0) {
            throw new InvalidArgumentException("The starting number must be a positive integer.");
        } else {
            $this->startingNumber = $startingNumber;
            $this->generateSequence();
        }
    }

    private function generateSequence(): void
    {
        $currentNumber = $this->startingNumber;
        // Initialize a new list with the user number as the first element.
        $sequence = array($currentNumber);

        // Loop until the sequence reaches the end value of one.
        while ($currentNumber > 1) {
            // If even, divide the number by 2.
            // If odd, multiply the number by 3, add 1, and divide by 2.
            $currentNumber = $currentNumber % 2 == 0 ? $currentNumber / 2 : (3 * $currentNumber + 1) / 2;
            // Add the new number to the sequence list.
            $sequence[] = $currentNumber;
        }

        // Set the Collatz Sequence.
        $this->collatzSequence = $sequence;
    }

    /**
     * Builds a string with all the values in collatzSequence, with
     * each value on its own line.
     *
     * @return string of the Collatz Sequence.
     */
    public function displaySequence(): string
    {
        return implode("\n", $this->collatzSequence);
    }
}