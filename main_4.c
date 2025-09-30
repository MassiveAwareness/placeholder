#include <time.h>
#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

static bool isPrime(int n) {
    if (n <= 1) return false;
    if (n <= 3) return true;
    if (n % 2 == 0 || n % 3 == 0) return false;

    for (int i = 5; i * i <= n; i += 6) {
        if (n % i == 0 || n % (i + 2) == 0) {
            return false;
        }
    }

    return true;
}

static int szamjegyekNegyzetosszege(int n) {
    int osszeg = 0;

    while (n > 0) {
        int szamjegy = n % 10;
        osszeg += szamjegy * szamjegy;
        n /= 10;
    }

    return osszeg;
}

static bool isBoldog(int n) {
    int lassú = n;
    int gyors = n;

    do {
        lassú = szamjegyekNegyzetosszege(lassú);
        gyors = szamjegyekNegyzetosszege(szamjegyekNegyzetosszege(gyors));

        if (gyors == 1) return true;
    } while (lassú != gyors);

    return false;
}


static void exercise1()
{
    printf("1. feladat\n");
    int num;

    do {
        printf("Input a number: ");
        scanf_s("%d", &num);
    } while (num < 100 || num > 999);

    printf("Scanned three-digit number: %d\n", num);
}

static void exercise2()
{
    printf("\n2. feladat\n");
    float num;

    for (int i = 0; i < 5; i++) {
        printf("Input a float number: ");
        scanf_s("%f", &num);
        printf("Number's double: %.2f\n", num * 2.00);
    }
}

static void exercise3()
{
    printf("\n3. feladat\n");
    float num;
    int positives = 0;

    for (int i = 0; i < 10; i++) {
        printf("Input a float number (%d/10): ", i + 1);
        scanf_s("%f", &num);

        if (num > 0) {
            positives++;
        }
    }

    printf("%d of them are positive.\n", positives);
}

static void exercise4()
{
    printf("\n4. feladat\n");
    int num;
    int evens = 0;

    while (1) {
        printf("Input a positive number: ");
        scanf_s("%d", &num);

        if (num <= 0) {
            break;
        }

        if (num % 2 == 0) {
            evens++;
        }
    }

    printf("%d of them are even.\n", evens);
}

static void exercise5()
{
    printf("\n5. feladat\n");
    float prev, current;
    int count = 0;

    printf("Input a float number: ");
    scanf_s("%f", &prev);
    count = 1;

    while (1) {
        printf("Input a float number: ");
        scanf_s("%f", &current);

        if (current >= prev) {
            break;
        }

        prev = current;
        count++;
    }

    printf("%d were correct.\n", count);
}

static void exercise6()
{
    printf("\n6. feladat\n");
    int width = 0, height = 0;

    printf("Width of rectangle: ");
    scanf_s("%d", &width);

    printf("Height of rectangle: ");
    scanf_s("%d", &height);

    for (int i = 0; i < height; i++) {
        for (int j = 0; j < width; j++) {
            printf("#");
        }
        printf("\n");
    }
}

static void exercise7()
{
    printf("\n7. feladat\n");
    int width = 0, height = 0;

    printf("Width of rectangle: ");
    scanf_s("%d", &width);

    printf("Height of rectangle: ");
    scanf_s("%d", &height);

    for (int i = 0; i < height; i++) {
        for (int j = 0; j < width; j++) {
            if (i == 0 || i == height - 1 || j == 0 || j == width - 1) {
                printf("#");
            }
            else {
                printf(" ");
            }
        }
        printf("\n");
    }
}

static void exercise8()
{
    printf("\n8. feladat\n");
    int num;

    printf("Input an integer: ");
    scanf_s("%d", &num);

    if (isPrime(num)) {
        printf("%d is prime.\n", num);
    }
    else {
        printf("%d is not prime.\n", num);
    }
}

static void exercise9()
{
    printf("\n9. feladat\n");
    printf("Star table 1-10:\n\n");

    printf("   |");
    for (int i = 1; i <= 10; i++) {
        printf("%4d", i);
    }
    printf("\n");

    printf("---+");
    for (int i = 1; i <= 10; i++) {
        printf("----");
    }
    printf("\n");

    for (int i = 1; i <= 10; i++) {
        printf("%2d |", i);
        for (int j = 1; j <= 10; j++) {
            printf("%4d", i * j);
        }
        printf("\n");
    }
}

static void exercise10()
{
    printf("\n10. feladat\n");
    int num, sum = 0;

    printf("Input an integer: ");
    scanf_s("%d", &num);

    int absolute = abs(num);

    while (absolute > 0) {
        sum += absolute % 10;
        absolute /= 10;
    }

    printf("Sum of %d: %d\n", num, sum);
}

static void exercise11()
{
    printf("\n11. feladat\n");
    printf("Primes less than 100:\n");

    for (int i = 2; i < 100; i++) {
        if (isPrime(i)) {
            printf("%d ", i);
        }
    }
    printf("\n");
}

static void exercise12()
{
    printf("\n12. feladat\n");
    int less_than_10 = 0;
    int num;

    srand(time(NULL));

    for (int i = 0; i < 200; i++) {
        num = rand() % 20;

        if (num < 10) {
            less_than_10++;
        }
    }

    printf("%d of them are less than 10.\n", less_than_10);
}

static void exercise13()
{
    printf("\n13. feladat\n");
    int num;
    int tries = 0;

    srand(time(NULL));

    do {
        num = rand() % 100;
        tries++;
    } while (!isPrime(num));

    printf("Generated prime: %d\n", num);
    printf("Count of tries: %d\n", tries);
}

static void exercise14()
{
    printf("\n14. feladat\n");
    int num;

    printf("Integer: ");
    scanf_s("%d", &num);

    if (isBoldog(num)) {
        printf("%d is happy.\n", num);
    }
    else {
        printf("%d is not happy.\n", num);
    }
}

int main()
{
    exercise1();
    exercise2();
    exercise3();
    exercise4();
    exercise5();
    exercise6();
    exercise7();
    exercise8();
    exercise9();
    exercise10();
    exercise11();
    exercise12();
    exercise13();
    exercise14();

    return 0;
}
