using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace sadf
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Node> Q1 = new Queue<Node>();
            Queue<Node> Q2 = new Queue<Node>();
            Queue<Node> Q3 = new Queue<Node>();
            Queue<Node> Q4 = new Queue<Node>();
            Queue<Node> Q5 = new Queue<Node>();
            Queue<Node> Q6 = new Queue<Node>(); 

            Queue<Node>[] QueueArray = { Q1, Q2, Q3, Q4, Q5, Q6 }; 

            string input = "1 ";

            int round = 0;

            while (input != "?")
            {
                Console.Write("Input : ");
                input = Console.ReadLine();

                if(input == "?")
                {
                    break;
                }

                Node n = new Node(input[0], input[1]);

                Q1.Enqueue(n);
            }

            for (int i = 1; i <= Q1.Count; i++)
            {
                Node d = Q1.Dequeue();

                int check = 0;

                int counter = 0;

                if (Q2.Count == 3 && Q3.Count == 3 && Q4.Count == 3 && Q5.Count == 3)
                {
                    round++;

                    Q2.Clear();
                    Q3.Clear();
                    Q4.Clear();
                    Q5.Clear();

                    Console.WriteLine("Q1 check");

                    break;
                }

                for (int k = 1; k < 5; k++)
                {


                    if (QueueArray[k].Count == 0 || QueueArray[k].ElementAt(0).GetInstruction() == d.GetInstruction())
                    {
                        if (QueueArray[k].Count == 3)
                        {
                            Q6.Enqueue(d);
                            check = 1;
                            break;
                        }
                        else
                        {
                            for (int z = 1; z < QueueArray[k].Count; z++)
                            {
                                if (QueueArray[k].ElementAt(0).GetData() == d.GetData())
                                {
                                    counter = 1;
                                    break;
                                }

                                if (counter == 0)
                                {
                                    QueueArray[k].Enqueue(d);
                                    check = 1;
                                    break;
                                }

                            }

                            if (counter == 1)
                            {
                                break;
                            }
                        }


                    }

                }
                if (check == 0)
                {
                    round++;

                    Q2.Clear();
                    Q3.Clear();
                    Q4.Clear();
                    Q5.Clear();                   

                    Console.WriteLine("Q2 clear");

                    break;
                }
            }


                while (Q1.Count != 0 || Q6.Count != 0)
                {
                int check = 0;
                int counter = 0;
                    if (Q6.Count > 0)
                    {
                        Node p = Q6.Dequeue();

                        for (int x = 1; x < 5; x++)
                        {
                            
                            if (QueueArray[x].Count == 0 || QueueArray[x].ElementAt(0).GetInstruction() == p.GetInstruction())
                            {
                                if (QueueArray[x].Count == 3)
                                {
                                    Q6.Enqueue(p);
                                    check = 1;
                                    break;
                                }
                                else
                                {
                                    for (int z = 1; z < QueueArray[x].Count; z++)
                                    {
                                        if (QueueArray[x].ElementAt(0).GetData() == p.GetData())
                                        {
                                            counter = 1;
                                            break;
                                        }

                                        if (counter == 0)
                                        {
                                            QueueArray[x].Enqueue(p);
                                            check = 1;
                                            break;
                                            
                                        }

                                        
                                    }

                                    if (counter == 1)
                                    {
                                         break;
                                    }
                            }
                            }
                        }

                        if (check == 0)
                        {
                            round++;

                            Q2.Clear();
                            Q3.Clear();
                            Q4.Clear();
                            Q5.Clear();

                         Console.WriteLine("Q3 clear");
                        }
                    }
                    else 
                    {
                        Node x = Q1.Dequeue();
                        
                        for (int q = 1; q < 5; q++)
                        {                          
                            if (QueueArray[q].Count == 0 || QueueArray[q].ElementAt(0).GetInstruction() == x.GetInstruction())
                            {
                                if (QueueArray[q].Count == 3)
                                {
                                    Q6.Enqueue(x);
                                    check = 1;
                                    break;
                                }
                                else
                                {
                                    for (int z = 1; z < QueueArray[q].Count; z++)
                                    {
                                        if (QueueArray[q].ElementAt(0).GetData() == x.GetData())
                                        {
                                            counter = 1;
                                            break;
                                        }

                                        if (counter == 0)
                                        {
                                            QueueArray[q].Enqueue(x); 
                                            check = 1;
                                            break;
                                        }
                                    }

                                    if(counter == 1)
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        if (check == 0)
                        {
                            round++;

                            Q2.Clear();
                            Q3.Clear();
                            Q4.Clear();
                            Q5.Clear();

                            Console.WriteLine("Q4 clear");

                            break;
                            
                        }

                        
                    }
                        
                }

            

            Console.WriteLine("CPU cycles needed : {0}",round);

            Console.ReadLine();
        }
    }

    class Node
    {
        protected char instruction;

        protected char data;

        public Node(char instruction , char data)
        {
            this.instruction = instruction;
            this.data = data;
        }

        public char GetInstruction()
        {
            return instruction ;
        }

        public char GetData()
        {
            return data ; 
        }
    }

    

    
}
