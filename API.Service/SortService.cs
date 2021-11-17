using System;
using API.Service.Interface;

namespace API.Service
{

    public delegate ISortService ServiceResolver(string key);
    public class WithoutInbuildFunctionSortService : ISortService
    {
        public int[] Sorting(int[] SortContent)
        {
            bool flag = true;
            int temp;
            int numLength = SortContent.Length;

            //sorting an array  
            for (int i = 1; (i <= (numLength - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (numLength - 1); j++)
                {
                    if (SortContent[j] > SortContent[j+1])
                    {
                         temp = SortContent[j+1];
                        SortContent[j + 1] = SortContent[j];
                         SortContent[j] = temp;
                         flag = true;
                    }
                }
            }

            return SortContent;
        }
    }

    public class InbuiltFunctionSortService : ISortService
    {
        public int[] Sorting(int[] SortContent)
        {
            Array.Sort(SortContent);
            return SortContent;
        }
    }
}
