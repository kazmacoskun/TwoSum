using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace twoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numsCount = 0;            
            List<int> nums = new List<int>();
            int target = 0;

            Random rnd = new Random();
            for (int i = 0;i<1200;i++)
            {
                nums.Add(i);
            }
            target = nums[nums.Count-1] + nums[nums.Count - 2];

                         
                       
            Binary(numsCount, target, nums);
            //Hash(numsCount, target, nums);
            //Brute(numsCount, target, nums);
        }
        public static void Hash(int numsCount, int target, List<int> nums)
        {
            Hashtable hashtable = new Hashtable();
            string indexHash = "";
            for (int i = 0; i < numsCount; i++)
            {
                int num = nums[i];
                int subs = target - num;
                if (hashtable.ContainsKey(subs))
                {
                    indexHash = "{" + ((hashtable[subs]).ToString()) + "," + i.ToString() + "}";
                }
                else if (!hashtable.ContainsKey(num))
                {
                    hashtable.Add(num, i);
                }
            }
            Console.WriteLine("Hash: " + indexHash);
        }
        public static void Brute(int numsCount, int target, List<int> nums)
        {
            string indexBrute = "";
            for (int i = 0; i < numsCount; i++)
                for (int j = i + 1; j < numsCount; j++)
                    if (nums[i] + nums[j] == target)
                        indexBrute = "{" + i.ToString() + "," + (j).ToString() + "}";
            Console.WriteLine("Brute: " + indexBrute);
        }
        public static void Binary(int numsCount, int target, List<int> nums)
        {
            string indexBinary = "";
            int searchedValueIndex = 0;
            for (int i = 0; i < numsCount; i++)
            {
                ushort searchedNumber = (ushort)(target - nums[i]);
                searchedValueIndex = nums.BinarySearch(searchedNumber);
                if (searchedValueIndex >= 0)
                {
                    indexBinary = "{" + i.ToString() + "," + (nums.IndexOf(searchedNumber)).ToString() + "}";
                    break;
                }
            }
            Console.WriteLine("Binary: " + indexBinary);
        }
    }
}
