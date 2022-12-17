namespace ParkingSystem
{
    internal class Program
    {
        private static int ParkSlot { get; set; } = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Parking System!");
            int menuNum = SelectMenu();

            switch (menuNum)
            {
                case 1:
                    if  (ParkSlot > 0)
                        Main(args);

                    ParkSlot = SetParkingSlot();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }

        private static int SetParkingSlot()
        {
            throw new NotImplementedException();
        }

        private static int SelectMenu()
        {
            int num;
            Console.WriteLine("1. Input Slot");
            Console.WriteLine("2. Park Vehicle");
            Console.WriteLine("3. Leave Vehicle");
            Console.WriteLine("4. Get Data With Criteria");
            Console.WriteLine("5. Exit");
            Console.WriteLine("");
            Console.Write("Select menu: ");
            bool isValid = int.TryParse(Console.ReadLine(), out num);
            if (isValid)
                return num;

            Console.Clear();

            return SelectMenu();
        }
    }
}