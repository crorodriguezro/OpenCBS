
using System;
using System.Diagnostics;

namespace OpenCBS.Stringifier
{
    public class Kazakh : Stringifiable
    {

        protected override string[] GetOneToNineteenArray()
        {
            return new[]
            {
                "",
                "бір",
                "екі",
                "үш",
                "төрт",
                "бес",
                "алты",
                "жеті",
                "сегіз",
                "тоғыз",
                "он",
                "он бір",
                "он екі",
                "он үш",
                "он төрт",
                "он бес",
                "он алты",
                "он жеті",
                "он сегіз",
                "он тоғыз"
            };
        }

        protected override string GetZero()
        {
            return "ноль";
        }

        protected override string GetOneToNineteen(int index, int[] arr, object param)
        {
            Debug.Assert(index >= 0 & index <= arr.Length, "Out of range");
            if (1 == arr.Length & 0 == arr[index]) return GetZero();
            return base.GetOneToNineteen(index, arr, param);
        }

        protected override string[] GetFirstOrderArray()
        {
            return new[]
            {
                "жиырма",
                "отыз",
                "қырық",
                "елу",
                "алпыс",
                "жетпіс",
                "сексен",
                "тоқсан"
            };
        }

        protected override string[] GetSecondOrderArray()
        {
            return new[]
            {
                "бір жүз",
                "екі жүз",
                "үш жүз",
                "төрт жүз",
                "бес жүз",
                "алты жүз",
                "жеті жүз",
                "сегіз жүз",
                "тоғыз жүз"
            };
        }

        protected override string GetThousand(int index, int[] arr)
        {
            Debug.Assert(3 == index, "Not a thousand");
            return "мың";
        }

        protected override string GetMillion(int index, int[] arr)
        {
            Debug.Assert(6 == index, "Not a million");
            return "миллион";
        }

        protected override string GetWhole(int whole)
        {
            return 1 == whole%10 & whole%100 != 11 ? "целая" : "целых";
        }

        protected override string GetTenths(int fraction)
        {
            return 1 == fraction%10 ? "десятая" : "десятых";
        }

        protected override string GetHundredths(int fraction)
        {
            return 1 == fraction%10 & fraction%100 != 11 ? "сотая" : "сотых";
        }

        protected override string GetPercent(decimal amount)
        {
            return "процент";
        }
    }
}
