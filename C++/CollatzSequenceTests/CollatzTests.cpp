#include "Collatz.h"
#include "gtest/gtest.h"

class ValidNumberParameterizedTests :public ::testing::TestWithParam<std::tuple<string, int>> {
protected:
    Collatz sequence;
};

class InvalidNumberParameterizedTests :public ::testing::TestWithParam<string> {
protected:
    Collatz sequence;
};

TEST_P(ValidNumberParameterizedTests, ValidNumberConstructorTest) {
    string startingNumber = std::get<0>(GetParam());
    int expected = std::get<1>(GetParam());

    sequence = Collatz(startingNumber);

    ASSERT_EQ(sequence.getSequenceLength(), expected);
}

TEST_P(InvalidNumberParameterizedTests, InvalidNumberConstructorTest) {
    string startingNumber = GetParam();

    try {
        sequence = Collatz(startingNumber);
        FAIL() << "Expected std::invalid_argument";
    }
    catch (std::invalid_argument const& ex) {
        EXPECT_EQ(ex.what(), std::string("Expected a non-negative integer, got \'" + startingNumber + "\'"));
    }
    catch (...) {
        FAIL() << "Expected std::invalid_argument";
    }
}

TEST_P(ValidNumberParameterizedTests, ValidNumberSetterTest) {
    string newStartingNumber = std::get<0>(GetParam());

    sequence = Collatz("1");
    ASSERT_EQ(sequence.getStartingNumber(), "1");

    sequence.setStartingNumber(newStartingNumber);
    ASSERT_EQ(sequence.getStartingNumber(), newStartingNumber);
}

TEST_P(InvalidNumberParameterizedTests, InvalidNumberSetterTest) {
    string newStartingNumber = GetParam();

    sequence = Collatz("1");
    try {
        sequence.setStartingNumber(newStartingNumber);
        FAIL() << "Expected std::invalid_argument";
    }
    catch (std::invalid_argument const& ex) {
        EXPECT_EQ(ex.what(), std::string("Expected a non-negative integer, got \'" + newStartingNumber + "\'"));
    }
    catch (...) {
        FAIL() << "Expected std::invalid_argument";
    }
}

TEST(ValidDisplayOutput, DisplaySequenceTest) {
    string expectedString = "5\n16\n8\n4\n2\n1\n";
    Collatz sequence = Collatz("5");
    
    string returnedString = sequence.displaySequence();
    EXPECT_EQ(returnedString, expectedString);
}

INSTANTIATE_TEST_CASE_P(
    CollatzTests,
    ValidNumberParameterizedTests,
    ::testing::Values(
        std::make_tuple("5", 6),
        std::make_tuple("50", 25),
        std::make_tuple("5000", 29),
        std::make_tuple("5000000", 145),
        std::make_tuple("5000000000", 124),
        std::make_tuple("5000000000000000000000000000000000000", 653)
    )
);

INSTANTIATE_TEST_CASE_P(
    CollatzTests,
    InvalidNumberParameterizedTests,
    ::testing::Values("0", "- 5")
);
