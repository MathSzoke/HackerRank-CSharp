public class Triangle
{
	// Check if the sides satisfy the triangle inequality theorem
	// The sum of the lengths of any two sides must be greater than the length of the third side.
    public static bool IsTriangle(int a, int b, int c) => (a + b > c) && (b + c > a) && (a + c > b);
}