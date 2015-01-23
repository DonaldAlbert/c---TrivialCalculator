using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLICalculator
{
    class UI
    {
        private bool running;
        private byte? selectedOperation;
        private Engine calcEng;
        private double operantA, operantB;

        
        public UI()
        {
            this.selectedOperation = null;
            this.calcEng = new Engine();
        }

        public void mainLoop()
        {
            this.running = true;

            while( this.running ) {
                this.interact();
                this.exitOrNext();
            }
        }

        private void exitOrNext()
        {
            System.Console.Write("Do you want to continue Y or N [Y]: ");
            string input = System.Console.ReadLine().Trim().ToLower();
            if (input == "n")
                this.running = false;
        }

        private void interact()
        {
            this.chooseOperation();

            bool validInput = true;
            do
                validInput = this.getOperant(out this.operantA, "Input operant A");
            while (!validInput);

            do
                validInput = this.getOperant(out this.operantB, "Input operant B");
            while (!validInput) ;

            this.calculate();
        }

        private void calculate()
        {
            double result = 0;

            switch (this.selectedOperation)
            {
                case 1:
                    result = this.calcEng.add(this.operantA, this.operantB);
                    break;
                case 2:
                    result = this.calcEng.subtract(this.operantA, this.operantB);
                    break;
                case 3:
                    result = this.calcEng.multiply(this.operantA, this.operantB);
                    break;
                case 4:
                    if (this.operantB == 0) {
                        System.Console.WriteLine("Division by zero not allowed.");
                        return;
                    } else {
                        result = this.calcEng.divide(this.operantA, this.operantB);
                    }
                    break;
            }

            System.Console.WriteLine("The result is {0}.", result);
        }

        private bool getOperant(out double operant, string message)
        {
            System.Console.Write(message+": ");
            string input = System.Console.ReadLine().Trim();

            return Double.TryParse(input, out operant);
        }

        public Boolean chooseOperation()
        {
            System.Console.WriteLine("Choose operation:");
            System.Console.WriteLine("    +");
            System.Console.WriteLine("    -");
            System.Console.WriteLine("    /");
            System.Console.WriteLine("    *");
            String input = System.Console.ReadLine();
            switch( input ) {
                case "+":
                    this.selectedOperation = 1;
                    break;
                case "-":
                    this.selectedOperation = 2;
                    break;
                case "*":
                    this.selectedOperation = 3;
                    break;
                case "/":
                    this.selectedOperation = 4;
                    break;
                default:
                    return false;
            }
            return true;
        }

        public void clearOperation() { this.selectedOperation = null; }



        public void readInput()
        {

        }


    }
}
