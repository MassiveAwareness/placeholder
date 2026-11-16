#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
// #include <math.h>

/* --- 1. alkalom --- */

// 1. feladat
//int main()
//{
//	printf("Hello world!\n");
//	return 0;
//}

// 2. feladat
//int main()
//{
//	printf("MassiveAwareness\n");
//	return 0;
//}

// 3. feladat
//int main()
//{
//	printf("John Wick\n");
//	printf("Selina Kyle\n");
//	printf("Groot\n");
//
//	return 0;
//}

/* --- 2. alkalom --- */

// 1. feladat
//int main()
//{
//	int number;
//	scanf_s("%d", &number);
//
//	printf("%d", number * 2);
//	return 0;
//}

// 2. feladat
//int main()
//{
//	int num1, num2;
//
//	scanf_s("%d", &num1);
//	scanf_s("%d", &num2);
//
//	printf("\n");
//	printf("%d\n", num1 * 2);
//	printf("%d\n", num2 * 2);
//
//	return 0;
//}

// 3. feladat
//int main()
//{
//	float num1, num2;
//	scanf_s("%f %f", &num1, &num2);
//
//	printf("\n");
//	printf("%f\n%f\n", num1, num2);
//
//	return 0;
//}

// 4. feladat
//int main()
//{
//	int num1, num2, num3;
//	scanf_s("%d %d %d", &num1, &num2, &num3);
//
//	printf("\n");
//	printf("%d + %d + %d = %d\n", num1, num2, num3, num1 + num2 + num3);
//	printf("%d / 5 remainder = %d\n", num1, num1 % 5);
//	printf("%d / 5 remainder = %d\n", num2, num2 % 5);
//	printf("%d / 5 remainder = %d\n", num3, num3 % 5);
//
//	return 0;
//}

// 5. feladat
//int main()
//{
//	float num1, num2, num3, num4;
//	scanf_s("%f %f %f %f", &num1, &num2, &num3, &num4);
//
//	printf("\n");
//	printf("%f - %f = %f\n", num2, num1, num2 - num1);
//	printf("%f / %f = %f\n", num4, num3, num4 / num3);
//
//	return 0;
//}

// 6. feladat
//float num1, num2, mul;
//
//void set_first()
//{
//	scanf_s("%f", &num1);
//}
//
//void set_second()
//{
//	scanf_s("%f", &num2);
//}
//
//void set_numbers()
//{
//	set_first();
//	set_second();
//}
//
//void calculate_mul()
//{
//	mul = num1 * num2;
//}
//
//void print_mul()
//{
//	printf("\nMultiplication of %f and %f: %.2f\n", num1, num2, mul);
//}
//
//void calculate()
//{
//	set_numbers();
//	calculate_mul();
//	print_mul();
//}
//
//int main()
//{
//	for (int i = 0; i < 3; i++) calculate();
//	return 0;
//}

// 7. feladat
//float side_a, side_b, side_c, area, volume, edges;
//
//void set_sides()
//{
//	scanf_s("%f", &side_a);
//	scanf_s("%f", &side_b);
//	scanf_s("%f", &side_c);
//}
//
//void calculate_details()
//{
//	edges = 4 * side_a + 4 * side_b + 4 * side_c;
//	area = 2 * (side_a * side_b + side_a * side_c + side_b * side_c);
//	volume = side_a * side_b * side_c;
//}
//
//void print_details()
//{
//	printf("Total edges length: %f cm.\n", edges);
//	printf("Total volume: %f cm.\n", volume);
//	printf("Total area: %f cm.\n", area);
//}
//
//int main()
//{
//	set_sides();
//	calculate_details();
//	print_details();
//
//	return 0;
//}

// 8. feladat
//int main()
//{
//	int comp_a, comp_b, comp_c;
//	scanf_s("%d %d %d", &comp_a, &comp_b, &comp_c);
//
//	printf("Competitor A: %d pts\nCompetitor B: %d pts\nCompetitor C: %d pts\nAverage points per competitors: %f", comp_a, comp_b, comp_c, (comp_a + comp_b + comp_c) / 3.0);
//	return 0;
//}

// 9. feladat
//int main()
//{
//	int integer;
//	unsigned int unsigned_integer;
//	float floating_point;
//	double double_floating_point;
//
//	scanf_s("%d", &integer);
//	scanf_s("%u", &unsigned_integer);
//	scanf_s("%f", &floating_point);
//	scanf_s("%lf", &double_floating_point);
//
//	printf("%d - %u = %u\n", integer, unsigned_integer, integer - unsigned_integer);
//	printf("%d - %f = %.2f\n", integer, floating_point, integer - floating_point);
//	printf("%d - %lf = %.2lf\n", integer, double_floating_point, integer - double_floating_point);
//	printf("%u - %d = %d\n", unsigned_integer, integer, unsigned_integer - integer);
//	printf("%u - %f  = %.2f\n", unsigned_integer, floating_point, unsigned_integer - floating_point);
//	printf("%u - %lf = %.2lf\n", unsigned_integer, double_floating_point, unsigned_integer - double_floating_point);
//	printf("%f - %d = %.2f\n", floating_point, integer, floating_point - integer);
//	printf("%f - %u = %.2f\n", floating_point, unsigned_integer, floating_point - unsigned_integer);
//	printf("%f - %lf = %.2lf\n", floating_point, double_floating_point, floating_point - double_floating_point);
//	printf("%lf - %d = %.2lf\n", double_floating_point, integer, double_floating_point - integer);
//	printf("%lf - %u = %.2lf\n", double_floating_point, unsigned_integer, double_floating_point - unsigned_integer);
//	printf("%lf - %f = %.2f\n", double_floating_point, floating_point, double_floating_point - floating_point);
//
//	return 0;
//}

/* --- 3. alkalom --- */

// 1. feladat
//int main()
//{
//	int num;
//	scanf_s("%d", &num);
//
//	if (num > 0) printf("%d is positive.\n", num);
//	else if (num < 0) printf("%d is negative.\n", num);
//	else printf("%d is equal to 0.\n", num);
//
//	return 0;
//}

// 2. feladat
//int main()
//{
//	int num1, num2;
//	scanf_s("%d %d", &num1, &num2);
//
//	if (num1 < num2) printf("num2 is greater.\n");
//	else if (num1 > num2) printf("num1 is greater.\n");
//	else printf("num1 and num2 are equal.\n");
//}

// 3. feladat
//int main()
//{
//	int num1, num2, num3;
//	scanf_s("%d %d %d", &num1, &num2, &num3);
//
//	if (num1 % 2 == 0 || num2 % 2 == 0 || num3 % 2 == 0) printf("Even number found!\n");
//	else printf("No even numbers found!\n");
//
//	return 0;
//}

// 4. feladat
//int main()
//{
//	int border_low, border_high;
//	scanf_s("%d %d", &border_low, &border_high);
//
//	if (border_low >= border_high)
//	{
//		printf("Lower boundary number cannot be greater than the higher boundary number.\n");
//		return 1;
//	}
//
//	int num;
//	scanf_s("%d", &num);
//
//	if (border_low < num && border_high > num) printf("%d is between %d and %d.\n", num, border_low, border_high);
//	else printf("%d is not between %d and %d.\n", num, border_low, border_high);
//
//	return 0;
//}

// 5. feladat
//int main()
//{
//	float numbers[4];
//	int count = 0;
//
//	for (int i = 0; i < 4; ++i)
//	{
//		scanf_s("%f", &numbers[i]);
//		if (numbers[i] < 0.0f) count++;
//	}
//
//	printf("Count of negative numbers: %d", count);
//	return 0;
//}

// 6. feladat
//int main()
//{
//	int width, height;
//	scanf_s("%d %d", &width, &height);
//
//	if (width > height) printf("Horizontal alignment.\n");
//	else if (height > width) printf("Vertical alignment.\n");
//	else printf("Square (width and height are equal).\n");
//
//	return 0;
//}

// 7. feladat
//int main()
//{
//	int num;
//	scanf_s("%d", &num);
//
//	if (num % 2 == 0) printf("Divisible by two.\n");
//	if (num % 3 == 0) printf("Divisible by three.\n");
//	if (num % 5 == 0) printf("Divisible by five.\n");
//	if (num % 7 == 0) printf("Divisible by seven.\n");
//
//	return 0;
//}

// 8. feladat
//int main()
//{
//	int border_low, border_high;
//	scanf_s("%d %d", &border_low, &border_high);
//
//	if (border_low == border_high)
//	{
//		printf("The two boundary numbers cannot be the same!\n");
//		return 1;
//	}
//
//	if (border_low > border_high)
//	{
//		int temp;
//		temp = border_low;
//		border_low = border_high;
//		border_high = temp;
//	}
//
//	int num;
//	scanf_s("%d", &num);
//
//	if (num > border_low && num < border_high) printf("%d is between %d and %d.\n", num, border_low, border_high);
//	else if (num == border_low || num == border_high) printf("%d is right at the boundary of the number range.\n", num);
//	else printf("%d is not between in the number range (%d and %d).\n", num, border_low, border_high);
//
//	return 0;
//}

// 9. feladat
int main()
{

}