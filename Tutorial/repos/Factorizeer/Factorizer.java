import java.util.Scanner;

public class Factorizer {
    public static void main(String[] args){

        // receives integer value from user
        Scanner sc = new Scanner(System.in);

        System.out.println("What number would you like to factor? ");
        int factor = sc.nextInt();
        int count = 0;
        int perfect = 0;
        int primeNum =0;

        System.out.println("The factors of "+ factor + " are:");

        // calculates & prints lists includes all factors
        // of that number.
        for (int i=1; i<=factor; i++){

            if ((factor % i) == 0){
                System.out.print(i + " ");
                count +=1;
            }
        }
        System.out.println();
        System.out.println(factor + " has "+ count+ " factors");

        for (int i=1; i<factor; i++){

            if ((factor % i) == 0) {
                perfect += i;
            }
        }
        if(perfect == factor){
            System.out.println(factor +" is a perfect number.");

        } else {
            System.out.println(factor +" is not a perfect number.");

        }
        if(count == 2){
            System.out.println(factor +" is a prime number." );
        } else {
            System.out.println(factor + " is not a prime number.");
        }
    }
}
