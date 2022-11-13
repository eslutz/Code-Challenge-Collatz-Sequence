import Collatz from './collatz';

test.each([
    ['5', 6],
    ['50', 25],
    ['5000', 29],
    ['5000000', 145],
    ['5000000000', 124],
    ['5000000000000000000000000000000000000', 653],
])('constructor called with a valid number', (starting_number: string, expected_count: number) => {
    const test_sequence = new Collatz(BigInt(starting_number));
    expect(test_sequence.get_sequence_length()).toBe(expected_count);
});

test.each([
    ['0'],
    ['-5'],
])('constructor called with a invalid number', (starting_number: string) => {
    expect(() => { new Collatz(BigInt(starting_number)); })
        .toThrowError('The starting number must be a positive integer.');
});

test.each([
    ['5', 6],
    ['50', 25],
    ['5000', 29],
    ['5000000', 145],
    ['5000000000', 124],
    ['5000000000000000000000000000000000000', 653],
])('setter called with a valid number', (starting_number: string, expected_count: number) => {
    const test_sequence = new Collatz(BigInt(1));
    test_sequence.set_starting_number(BigInt(starting_number));
    expect(test_sequence.get_sequence_length()).toBe(expected_count);
});

test.each([
    ['0'],
    ['-5'],
])('setter called with a invalid number', (starting_number: string) => {
    const test_sequence = new Collatz(BigInt(1));
    expect(() => { test_sequence.set_starting_number(BigInt(starting_number)); })
        .toThrowError('The starting number must be a positive integer.');
});

test('display sequence', () => {
    const expected_string = '5\n16\n8\n4\n2\n1';
    const test_sequence = new Collatz(BigInt(5));
    const returned_string = test_sequence.display_sequence();
    expect(returned_string).toBe(expected_string);
});

test('get starting number', () => {
    const test_starting_number = BigInt(5);
    const test_sequence = new Collatz(test_starting_number);
    expect(test_sequence.get_starting_number()).toBe(test_starting_number);
});

test('returned sequence is immutable', () => {
    const test_sequence = new Collatz(BigInt(5));
    expect(Object.isFrozen(test_sequence.get_collatz_sequence())).toBe(true);
});
