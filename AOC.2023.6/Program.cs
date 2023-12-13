using System.Numerics;

namespace AOC._2023._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Part 1:
            //int[] timeRecord = { 38, 67, 76, 73 };
            //int[] distanceRecord = { 234,1027,1157,1236};

            // Eksampel:
            //int[] timeRecord = { 7, 15, 30};
            //BigInteger[] distanceRecord = { 9, 40, 200};

            // Part 2:
            int[] timeRecord = { 38677673};
            BigInteger[] distanceRecord = { 234102711571236 };

            //Console.WriteLine("\n"+part1(timeRecord,distanceRecord));

            part2(timeRecord, distanceRecord);


        }
        static BigInteger part1(int[] timeRecord, BigInteger[] distanceRecord)
        {
            BigInteger totalCount = 1;
            for (int i = 0; i < timeRecord.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < timeRecord[i]; j++)
                {
                    BigInteger speed = timeRecord[i] - j;
                    BigInteger distance = 0;
                    for (int k = 0; k < j; k++)
                    {
                        distance += speed;
                    }

                    if (distance > distanceRecord[i])
                    {
                        count++;
                    }
                }
                Console.WriteLine(count);
                if (count > 0) totalCount *= count;
            }

            return totalCount;
        }

        static void part2(int[] timeRecord, BigInteger[] distanceRecord)
        {
            BigInteger totalCount = 1;
            for (int i = 0; i < timeRecord.Length; i++)
            {
                int indexLow = 0;
                for (int j = timeRecord[i]; j > 0; j--)
                {
                    BigInteger speed = j;
                    BigInteger distance = speed * (timeRecord[i] - j);
                    if (distance > distanceRecord[i])
                    {
                        indexLow = j;
                        break;
                    }
                }
                int indexHigh = 0;
                for (int j = 0; j < timeRecord[i]; j++)
                {
                    BigInteger speed = timeRecord[i] - j;
                    BigInteger distance = speed * j;
                    if (distance > distanceRecord[i])
                    {
                        indexHigh = j;
                        break;
                    }
                }
                if (indexHigh != indexLow) totalCount *= indexLow - indexHigh + 1;
            }
            Console.WriteLine(totalCount);
        }
    }
}
