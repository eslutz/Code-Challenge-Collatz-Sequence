#include "BigInt.h"

#include <string>
#include <vector>

using namespace std;

/**
 * Collatz class for generating a Collatz Sequence from a starting value.
 *
 * @author Eric Slutz
 */
class Collatz {
private:
    BigInt startingNumber;
    vector<BigInt> collatzSequence;
    void generateSequence();
public:
    explicit Collatz(const string& startingNumber = "");

    [[maybe_unused]] string getStartingNumber();
    [[maybe_unused]] void setStartingNumber(const string& newStartingNumber);
    [[maybe_unused]] int getSequenceLength();
    [[maybe_unused]] vector<string> getCollatzSequence();
    [[maybe_unused]] string displaySequence();
};
