
bool r = true;
string[] taskarray = new string[0];
int[] statusInt = new int[0];
DateTime[] time = new DateTime[0];

bool Check(string name)
{
    foreach (string s in taskarray)
    {
        if (s == name)
        {
            return true;
        }
    }

    return false;
}
string task;
string List()
{
    foreach (string s in taskarray)
        Console.WriteLine(s);
    Console.WriteLine("write one of the tasks below Which you want to use");
    task = Console.ReadLine().ToLower();
    return "d";
}


while (true)
{
    DateTime date;
    Console.WriteLine("choise a comand ");
    string comand = Console.ReadLine();
    int status;
    switch ((comand.ToLower()))
    {
        case "add-item":
            Console.WriteLine("Enter item ");
            task = Console.ReadLine().ToLower();
            if (Check(task))
            {
                continue;
            }
            if (task == "")
                continue;

            Array.Resize<string>(ref taskarray, taskarray.Length + 1);
            Array.Resize<int>(ref statusInt, statusInt.Length + 1);
            Array.Resize<DateTime>(ref time, time.Length + 1);

            taskarray[taskarray.Length - 1] = task;


            break;
        case "remove-item":

            List();
            if (task == "*")
            {

                Array.Resize<string>(ref taskarray, taskarray.Length - taskarray.Length);
                Array.Resize<int>(ref statusInt, statusInt.Length - statusInt.Length);
                Array.Resize<DateTime>(ref time, time.Length - time.Length);

                break;
            }
            if (!Array.Exists(taskarray, x => x.ToLower() == task))
            {
                continue;
            }



            for (int i = 0; i < taskarray.Length; i++)
            {
                if (taskarray[i] == task)
                {
                    for (int y = i; y < taskarray.Length; y++)
                    {
                        if (y + 1 == taskarray.Length)
                        {
                            break;
                        }
                        taskarray[y] = taskarray[y + 1];
                        statusInt[y] = statusInt[y + 1];
                        time[y] = time[y + 1];
                    }
                    break;
                }
            }

            Array.Resize<string>(ref taskarray, taskarray.Length - 1);
            Array.Resize<int>(ref statusInt, statusInt.Length - 1);
            Array.Resize<DateTime>(ref time, time.Length - 1);

            break;

        case "mark-as":
            List();
            if (!Check(task))
            {
                continue;
            }

            Console.WriteLine("Enter status ");
            status = int.Parse(Console.ReadLine());

            if (status != 0 && status != 1)
            {
                Console.WriteLine("wrong status");
                continue; ;
            }

            for (int i = 0; i < taskarray.Length; i++)
            {
                if (taskarray[i] == task)
                {
                    statusInt[i] = status;
                }
            }
            for (int i = 0; i < taskarray.Length; i++)
            {
                if (statusInt[i] == 1 && taskarray[i] == task)
                {


                    date = DateTime.Today;
                    time[i] = date;
                    i = taskarray.Length + 1;

                }

            }


            break;

        case "show":

            Console.WriteLine("Enter status ");


            if (!int.TryParse(Console.ReadLine(), out status))
            {
                Console.WriteLine("All of status 1");
                for (int i = 0; i < taskarray.Length; i++)
                {
                    if (statusInt[i] == 1)
                    {
                        Console.WriteLine(taskarray[i] + " " + time[i]);
                    }
                }
                Console.WriteLine("All of status 0");
                for (int i = 0; i < taskarray.Length; i++)
                {
                    if (statusInt[i] == 0)
                    {
                        Console.WriteLine(taskarray[i]);
                    }
                }
            }
            
            
                
            for (int i = 0; i < taskarray.Length; i++)
            {
                if (status == 1 && statusInt[i] == 1)
                {
                    Console.WriteLine(taskarray[i] + " " + time[i]);

                }
                else if (status == 0 && statusInt[i] == 0)
                {
                    Console.WriteLine(taskarray[i]);
                }
            }

            break;
    }
}





//DateTime now = DateTime.Now;
//Random random = new Random();
//short tempruture = (short)random.Next(-30, 40);
//Console.WriteLine("Введите команду какую хотите использовать : ");
//string choise = Console.ReadLine();
//DateTime thisDay = DateTime.Today;

