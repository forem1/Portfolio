using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truth
{
    class TruthTable
    {
        public string Example;
        public string Elements;
        public bool[,] Table;
        private int Step;
        public int TableSize;

        public void FindElementAmount(string Example)
        {
            this.Example = Example;
            string Elements = "";
            for (int i = 0; i < Example.Length; i++)
            {
                if ((Example[i] >= 'A') && (Example[i] <= 'Z'))
                {
                    if (Elements.Length > 0)
                    {
                        bool coincidence = false;
                        for (int i1 = 0; i1 < Elements.Length; i1++) if (Example[i] == Elements[i1]) coincidence = true;
                        if (!coincidence) Elements += Example[i];
                    }
                    else Elements += Example[i];
                }
            }
            this.Elements = Elements;
            this.Table = new bool[Example.Length, Convert.ToInt32(Math.Pow(2, Elements.Length))];
            TableSize = Convert.ToInt32(Math.Pow(2, Elements.Length));
        }

        public void FillingElements()
        {
            double a = Math.Pow(2, this.Elements.Length); 
            for (int i = 0; i < this.Elements.Length; i++)
            {
                int Counter = 0;
                for (int i1 = 0; i1 < Math.Pow(2, this.Elements.Length); i1++)
                {
                    if (Counter < (a / 2)) this.Table[i, i1] = false;
                    if (Counter >= (a / 2)) this.Table[i, i1] = true;
                    if (Counter == a)
                    {
                        this.Table[i, i1] = false;
                        Counter = 0;
                    }
                    Counter++;
                }
                a /= 2;
            }
        }

        private void Inversion(int Position)
        {
            string NewExample = "";
            int TablePosition = 0;
            for (int i = 0; i < Elements.Length; i++) if (Elements[i] == Example[Position + 1]) TablePosition = i;
            for (int i = 0; i < TableSize; i++) Table[Elements.Length, i] = !Table[TablePosition, i];
            Elements += Convert.ToString(Step);
            Console.WriteLine(Step + " - " + Example[Position] + Example[Position + 1]);
            for (int i = 0; i < Position; i++) NewExample += Example[i];
            NewExample += Convert.ToString(Step);
            for (int i = Position + 2; i < Example.Length; i++) NewExample += Example[i];
            Example = NewExample;
            Step++;
            //Console.WriteLine(Step);
        }

        private void Operation(int Position, int OperationNumber)
        {
            string NewExample = "";
            int TablePositionFirst = 0;
            int TablePositionSecond = 0;
            for (int i = 0; i < Elements.Length; i++) if (Elements[i] == Example[Position - 1]) TablePositionFirst = i;
            for (int i = 0; i < Elements.Length; i++) if (Elements[i] == Example[Position + 1]) TablePositionSecond = i;
            switch (OperationNumber)
            {
                case 1:
                    for (int i = 0; i < TableSize; i++) Table[Elements.Length, i] = Table[TablePositionFirst, i] & Table[TablePositionSecond, i];
                    break;
                case 2:
                    for (int i = 0; i < TableSize; i++) Table[Elements.Length, i] = Table[TablePositionFirst, i] | Table[TablePositionSecond, i];
                    break;
                case 3:
                    for (int i = 0; i < TableSize; i++)
                    {
                        if (Table[TablePositionFirst, i] && (!Table[TablePositionSecond, i])) Table[Elements.Length, i] = false;
                        else Table[Elements.Length, i] = true;
                    }
                    break;
                case 4:
                    for (int i = 0; i < TableSize; i++)
                    {
                        if (Table[TablePositionFirst, i] == Table[TablePositionSecond, i]) Table[Elements.Length, i] = true;
                        else Table[Elements.Length, i] = false;
                    }
                    break;
            }
            Elements += Convert.ToString(Step);
            Console.WriteLine(Step + " - " + Example[Position - 1] + Example[Position] + Example[Position + 1]);
            for (int i = 0; i < Position - 1; i++) NewExample += Example[i];
            NewExample += Convert.ToString(Step);
            for (int i = Position + 2; i < Example.Length; i++) NewExample += Example[i];
            Example = NewExample;
            Step++;
        }

        private void Calculation(char Operation, int OperationNumber) // Да какого хора!?
        {
            int ActionPosition = 0;
            while (ActionPosition != -1)
            {
                //Console.WriteLine(ActionPosition);
                ActionPosition = -1;
                for (int i = 0; i < Example.Length; i++) if (Example[i] == Operation)
                    {
                        ActionPosition = i;
                        break;
                    }
                if (ActionPosition != -1) this.Operation(ActionPosition, OperationNumber);
            }
        }
        public void Main()
        {
            Step = 1;
            int ActionPosition = 0;
            while (ActionPosition != -1)
            {
                ActionPosition = -1;
                for (int i = 0; i < Example.Length; i++) if (Example[i] == '!')
                    {
                        //Console.WriteLine(i);
                        ActionPosition = i;
                        break;
                    }
                if (ActionPosition != -1) Inversion(ActionPosition);
            }
            Calculation('&', 1); //Не работает, исправить!!!
            Calculation('|', 2);
            Calculation('>', 3);
            Calculation('=', 4);
        }

        public void Output()
        {
            Console.WriteLine();
            for (int i = 0; i < Elements.Length; i++) Console.Write("| " + Elements[i] + " ");
            Console.WriteLine("|");
            Console.WriteLine("asd");
            Console.Write("*");
            for (int i = 0; i < Elements.Length - 1; i++) Console.Write("----");
            Console.Write("----");
            Console.WriteLine("*");
            for (int i = 0; i < TableSize; i++)
            {
                for (int i1 = 0; i1 < Elements.Length; i1++)
                {
                    if (Table[i1, i]) Console.Write("| 1 ");
                    else Console.Write("| 0 ");
                }
                Console.Write("|");
                Console.WriteLine("Hey!");
            }
        }
    }
}
