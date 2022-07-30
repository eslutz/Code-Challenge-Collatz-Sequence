#include "Collatz.h"

#include <iostream>
#include <vector>

using namespace std;

int main() {
    // Display welcome message
    cout << "Welcome to the Collatz Conjecture Sequence Generator!" << endl;

    // Initialize variable for keeping track of if the program is running.
    auto quitProgram = false;
    // Start program loop until the user quits.
    while (!quitProgram) {
        // Declare variable for storing user input.
        string userInput;
        Collatz collatzSequence;

        // Prompt the user for input.
        cout << "\nEnter a positive integer (enter q to quit) => ";
        cin >> userInput;

        // Converts user input to lower case.
        for (char& i : userInput) {
            i = tolower(i);
        }

        // String array with possible input for quit.
        vector<string> quitResponse{ "q", "quit" };
        // Check if user wants to quit the program.
        quitProgram = ((find(quitResponse.begin(), quitResponse.end(), userInput) != quitResponse.end()) == 1);
        if (quitProgram) {
            continue;
        }

        // Attempt to initialize Collatz Sequence from user input..
        try {
            // Instantiate new Collatz instance, passing in user input.
            collatzSequence = Collatz(userInput);
        }
        catch (...) {
            // Prompt user for input again.
            cout << endl << "Not a valid positive integer. Try again." << endl;
            // Clear the input buffer.
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            continue;
        }

        // Print out the Collatz Sequence.
        cout << collatzSequence.displaySequence();
        // Print the sequence length.
        cout << endl << "Sequence Length: " << collatzSequence.getSequenceLength() << endl;
    }
    // Display goodbye message.
    cout << "\nGoodbye!" << endl;

    return 0;
}
