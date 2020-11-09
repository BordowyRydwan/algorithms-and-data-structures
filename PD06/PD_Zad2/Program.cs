using System;
using System.Collections.Generic;

/*
           Wyjasnienie dzialania:

           Dane: 
           - lista transmisji (w programie listę transmisji reprezentuje klasa Schedule, a samą transmisję klasa Range)

           Najpierw tworzę tablicę reprezentującą konkretne punkty w czasie, których są transmisje. Wartośc tablicy w danym indeksie zalezy od
           tego ile transmisji na raz odbywa się w tym czasie. Naszym celem jest, żeby transmisji w jednym czasie odbywało się dokładnie jedna 
           lub zero. Będziemy więc wyjmować z naszego pełnego koszyczka transmisje tak, aby w każdym czasie była max 1 transmisja.

           Wiemy intuicyjnie, że skoro każda transmisja ma to samo wynagrodzenie, to, gdy mamy wybór, którą transmisję wyrzucić, to potencjalnie 
           z większą ilością rzeczy będzie kolidować ta najdłuższa - sortuję więc na samym początku listę transmisji po ich długości (odwrotnie).

           n - długość od 0 do najpozniejszego konca transmisji
           m - dlugosc listy transmisji
           mLen_i - długosc i-tej transmisji

           Algorytm:
               1. wypełnienie tablicy godzin ilością transmisji w danym czasie (O(n * m))
               2. posortowanie tablicy transmisji - O(m * log(m))
               3. całość szukania indeksów tablicy godzin, które trzeba powyrzucać, to O(m*n)
                   a) przeszukiwanie tablicy godzin - O(n)
                   b) przeszukiwanie konkretnego indeksu godzin, czy wystpuje we wszystkich przedzialach - O(m)
               4. wyrzucanie godzin - O(n * m * mLen_i)

           Najwyższą z tych złożoności jest O(n * m * mLen_i). Jednak m*len_i nie może być większe niż n - indeksów do zamiany w jednej iteracji 
           zawsze może być maksymalnie tyle ile ich istnieje, czyli n. Złożonośc czasowa to więc O(n^2).

           Złożoność pamięciowa zależy wyłącznie od tablicy godzin - jest więc O(n).

           ZŁOŻONOŚĆ:
               - algorytymiczna - O(n^2)
               - pamięciowa     - O(n)
*/

namespace PD_Zad2
{
    class Program
    {
        static int Partition(List<Range> arr, int left, int right, Range pivot)
        {
            while (left <= right)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    Range tmp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = tmp;

                    left++;
                    right--;
                }
            }

            return left;
        }

        static void QuickSort(List<Range> arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int randomIndex = new Random().Next(left, right);
            Range pivot = arr[randomIndex];
            int partition = Partition(arr, left, right, pivot);

            QuickSort(arr, left, partition - 1);
            QuickSort(arr, partition, right);
        }

        class Range : IComparable<Range>
        {
            public readonly int start;
            public readonly int end;

            public int Length {
                get
                {
                    return end - start + 1;
                }
            }

            public Range(int start, int end)
            {
                if (end < start)
                {
                    this.end = start;
                    this.start = end;
                }
                else
                {
                    this.start = start;
                    this.end = end;
                }
            }

            public static bool IsNumberInRange(int num, Range range)
            {
                if(range != null)
                {
                    return num >= range.start && num < range.end;
                }

                return false;
            }

            public override string ToString()
            {
                return "(" + start + ", " + end + ")";
            }

            public int CompareTo(Range r)
            {
                if (this.Length > r.Length)
                {
                    return 1;
                }
                else if (this.Length < r.Length)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            public static bool operator >(Range r1, Range r2)
            {
                if(r1.CompareTo(r2) == 1)
                {
                    return true;
                }

                return false;
            }

            public static bool operator <(Range r1, Range r2)
            {
                return r2 > r1;
            }
        }

        class Schedule
        {
            List<Range> activities;
            int hourMin;
            int hourMax;

            public Schedule(List<Range> activities)
            {
                this.activities = activities;
                this.hourMin = this.ScheduleScopes.start;
                this.hourMax = this.ScheduleScopes.end;

                this.SortByLengthOfRange();
            }

            private Range ScheduleScopes
            {
                get
                {
                    int min = activities[0].start;
                    int max = activities[0].end;

                    foreach (Range activity in activities)
                    {
                        if(activity.start < min)
                        {
                            min = activity.start;
                        }

                        if (activity.end > max)
                        {
                            max = activity.end;
                        }
                    }

                    return new Range(min, max);
                }
            }

            public int Length
            {
                get
                {
                    return hourMax - hourMin + 1;
                }
            }

            public int[] ActivitiesCountByHours
            {
                get
                { 
                    int[] resultArray = new int[Length];

                    for(int i = 0; i < resultArray.Length; ++i)
                    {
                        resultArray[i] = 0;
                    }

                    foreach(Range activity in activities)
                    {
                        for(int i = activity.start; i < activity.end; ++i)
                        {
                            resultArray[i]++;
                        }
                    }

                    return resultArray;
                }
            }

            public void SortByLengthOfRange()
            {
                QuickSort(activities, 0, activities.Count - 1);

                activities.Reverse();
            }

            public void ClearNotSeparateActivities() //wlasciwy algorytm
            {
                int[] activitiesCounters = this.ActivitiesCountByHours;

                this.SortByLengthOfRange();

                for(int i = 0; i < activitiesCounters.Length; ++i)
                {
                    List<int> indexesToDelete = new List<int>();

                    if(activitiesCounters[i] > 1)
                    {
                        int activitiesToDelete = activitiesCounters[i] - 1;
                        int j = 0;

                        while(activitiesToDelete > 0 && j < activities.Count)
                        {
                            if(Range.IsNumberInRange(i, activities[j]))
                            {
                                indexesToDelete.Add(j);
                                activitiesToDelete--;
                            }

                            j++;
                        }
                    }

                    for (int j = 0; j < indexesToDelete.Count; ++j)
                    {
                        for(int k = activities[indexesToDelete[j]].start; k <= activities[indexesToDelete[j]].end; k++)
                        {
                            activitiesCounters[k]--;
                        }
                    }

                    for (int j = 0; j < indexesToDelete.Count; ++j)
                    {
                        activities[indexesToDelete[j]] = null;
                    }
                }
            }

            public override string ToString()
            {
                string result = "";

                foreach(Range activity in activities)
                {
                    if(activity != null)
                    {
                        result += activity + "\n";
                    }
                }

                return result;
            }
        }

        static void Main(string[] args)
        {
            List<Range> relations = new List<Range>()
            {
                new Range(0, 3),
                new Range(4, 6),
                new Range(5, 9),
                new Range(8, 10),
                new Range(11, 15),
            };

            Schedule schedule = new Schedule(relations);

            schedule.ClearNotSeparateActivities(); //wykonanie algorytmu

            Console.WriteLine(schedule); // wypisanie parami rozłącznych zbiorów
            Console.Read();
        }
    }
}
