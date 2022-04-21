namespace CollatzSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a positive integer => ");
            var userInput = Console.ReadLine();
            var vaildNumberInput = ulong.TryParse(userInput, out ulong userNumber);

            while (!vaildNumberInput)
            {
                Console.WriteLine("Not a valid positive integer. Try again.");
                Console.Write("Enter a positive integer => ");
                userInput = Console.ReadLine();
                vaildNumberInput = ulong.TryParse(userInput, out userNumber);
            }

            var collatzSequence = GetCollatzSequence(userNumber);

            collatzSequence.ForEach(Console.WriteLine);
        }

        static List<ulong> GetCollatzSequence(ulong number)
        {
            var collatzSequence = new List<ulong>() { number };

            do
            {
                number = number % 2 == 0 ? number / 2 : 3 * number + 1;
                collatzSequence.Add(number);
            }
            while (number > 1);

            return collatzSequence;
        }
    }
}