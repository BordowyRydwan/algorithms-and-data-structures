# Homework 6

## ENG

1. You're placed on the left top corner of 2D rectangle mesh, sized m * n. You want to go to the right bottom corner but every point-to-point passage has an assigned reward for passing it (you can only go bottom or right). Your task is to find a way with a maximum reward of passing the way.

Write an algorithm solving this task.

2. Knapsack problem - you have a backpack of N liters volume. You are given a set of items - volumes of items I[] and values of items V[]. Your task is to tell which items you gotta take to achive the highest possbile value.

Write an algorithm solving this task.

3. Find the longest common subsequence of two strings. For example, for s1 = "ABCBDAB", s2 ="BDCABA" the longest common subsequence is "BCBA".

4. Definition of relation is a pair (time_start, time_end). Two relations are separated on the schedule if for two relations R1(a_start, a_end) and R2(b_start, b_end) the expression "b_start >= a_end && a_start >= b_end" is true.

Your task is to make a schedule with as many relations as possible from the given set of relations.

Use the dynamic programming paradigm.

## PL

1. Mamy prostokątną siatkę, mamy przejść od lewego górnego rogu do prawego dolnego przesuwając się tylko w dół lub w prawo.  Każdej ścieżce przypisana jest nagroda, należy wybrać drogę tak, aby sumaryczna nagroda była największa. Oceń złożoność rozwiązania

2. Dyskretny problem plecakowy. Jest N przedmiotów. Każdy waży wikilogramów i kosztuje ci. Możemy unieść maksymalnie K kilogramów. Które przedmioty wziąć, aby łączna wartość zabranych towarów była jak największa? Oceń złożoność rozwiązania.

3. Najdłuższy wspólny podciąg. Mamy dwa ciągi: xi oraz yi. Chcemy znaleźć najdłuższy wspólny podciąg. Na przykład dla ABCBDAB i BDCABA może to być BCBA. Oceń złożoność rozwiązania.

4. Tworzymy relację sportową w której chcemy umieścić jak największą liczbę wydarzeń (możemy umieścić tylko całe wydarzenia). Za pokazanie każdego wydarzenia otrzymujemy od sponsora wydarzenia taką samą kwotę.  Dany jest zbiór wydarzeń Z={z1,...,zn} gdzie zi to para: czas rozpoczęcia si, czas zakończenia fi .Zawsze fi>  si oznaczamy parę jako przedział [ si , fi ). Wybrać w Z najliczniejszy podzbiór parami zgodnych wydarzeń aby zmaksymalizować przychód (kwota od sponsora może być przyjęta jako 1). Wydarzenia [si , fi) i [sj , fj) zgodne, gdy: sj>=fi lub si>=fj. Wydarzenia podane w zbiorze Z nie są uporządkowane. Należy wykorzystać podejście dynamiczne. Oceń złożoność i zilustruj działanie algorytmu dla samodzielnie wybranych danych.



