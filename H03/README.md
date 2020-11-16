# Homework 3

## ENG

1. Write an algorithm raising number `a` to the `n` power which is:
  * naive
  * recursive using "Divide and Conquer" method
  * dynamic

  Define time complexity of each algorithm.

2. Write the recursive ternary search algorithm. After that, form a recursive equation describing the execution time for every data size.

3. Problem of making a schedule from a given set of courses:
```
Definition of course is a pair (time_start, time_end). Two courses are separated on the schedule if for two courses C1(a_start, a_end) and C2(b_start, b_end) the expression "b_start >= a_end && a_start >= b_end" is true.

Your task is to make a schedule with as many courses as possible from the given set of courses.

Use the greedy algorithm. 

Hint: sort the courses by the start time.
```

4. Giving exchange problem:
```
You have N dollars on the account and you want them to be changed into coins included in array of values V: [v_1, v_2, ..., v_n].

Write an algorithm using dynamic programming paradigm which tells in how many differentiable ways your money can be exchanged.

Hint:

Let w[i] be a number of possible ways of exchanging money for value V[i]. Following expression is true:

w[i] = w[i - 1] + w[i - 2] + ... + w[0]
```

## PL

1. Opracuj algorytm podnoszenia liczby do potęgi naturalnej a^n, wykorzystując mnożenie. 
  * Opracuj prosty (naiwny) algorytm iteracyjny i oceń jego złożoność. 
  * Opracuj algorytm rekurencyjny (dziel i zwyciężaj) i oceń jego złożoność. Zauważ, że np. a^11 = a*((a^5)^2), z kolei a^5 = a*((a^2)^2). 
  * Jeżeli masz do obliczenia wiele potęg liczby a to przydałaby się strategia oparta na programowaniu dynamicznym. Opracuj na bazie algorytmu rekurencyjnego taki algorytm.

2. Opracuj metodę rekurencyjną wyszukiwania trójkowego (ternarnego - dzielenie przedziału na 3). Wyprowadź równanie rekurencyjne na złożoność. 

3. Problem wyboru zajęć. Dane: Zbiór zajęć Z={z1,...,zn} gdzie zi to para: czas rozpoczęcia si , czas zakończenia fi . Ozn. [ si , fi ) , fi >= si. Wybrać w Z największy podzbiór parami zgodnych zajęć.

zi = [si , fi) i [sj , fj) zgodne, gdy: sj>=fi lub si>=fj. Należy wykorzystać podejście zachłanne. Wskazówka: posortować zajęcia po czasie rozpoczęcia.

4. Na ile sposobów można wydać resztę r dysponując nieograniczoną liczbą monet(banknotów) o k różnych nominałach {n1,n2,     ...,nk} ? Skorzystaj z programowania dynamicznego.

```
Np. Dysponując monetami o nominałach 1, 2 i 5, resztę 5  możemy wydać na 4 sposoby:

1 + 1 + 1 + 1 + 1
1 + 1 + 1 + 2
1 + 2 + 2
5

Wskazówka 1:

Rozważyć liczbę sposobów s[i] dla kwot 0,1,2,…, reszta

s[i] to suma sposobów s[i-n1] + s[i-n2]+…+s[i-nk]

Uwaga: Szukamy rozwiązania, które utożsamia sposoby będące permutacjami, dla nominałów 1, 2 i 5 oraz reszty 5  

1 + 1 + 1 + 2 = 2 + 1 + 1 + 1 = 1 + 2 + 1 + 1 = 1 + 1 + 2 + 1  

oraz 1 + 2 + 2 = 2 + 1 + 2 =  2 + 2 + 1

Wskazówka 2:

Rozważ najpierw liczbę sposobów dla pierwszego nominału np. 1. Potem dla dwóch nominałów np, 1 i 2, znając już liczbę dla jednego nominału itd. dla k+1 nominałów znając liczbę sposobów dla k nominałów
```


