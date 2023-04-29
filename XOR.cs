using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronXOR
{
    class XOR

    {
        class obtener
        {
            public static double salida2(double x)
            {
                return 1.0 / (1.0 + Math.Exp(-x));
            }

            public static double salidDev(double x)
            {
                return x * (1 - x);
            }
        }

        class Neurona
        {
            public double[] inputs = new double[2];
            public double[] weights = new double[2];
            public double error;

            private double biasWeight;

            private Random r = new Random();

            public double output
            {
                get { return obtener.salida2(weights[0] * inputs[0] + weights[1] * inputs[1] + biasWeight); }
            }

            public void pesosrandom()
            {
                weights[0] = r.NextDouble();
                weights[1] = r.NextDouble();
                biasWeight = r.NextDouble();
            }

            public void peso2()
            {
                weights[0] += error * inputs[0];
                weights[1] += error * inputs[1];
                biasWeight += error;
            }
        }
        static void Main(string[] args)
        {
            double[,] datos = { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } };
            double[] resul = { 0, 1, 1, 0 };


            Neurona N1 = new Neurona();
            Neurona N2 = new Neurona();
            Neurona salida = new Neurona();


            N1.pesosrandom();
            N2.pesosrandom();
            salida.pesosrandom();
            int contador = 0;
         Var:
            contador++;
            for (int i = 0; i < 4; i++)
            {


                N1.inputs = new double[] { datos[i, 0], datos[i, 1] };
                N2.inputs = new double[] { datos[i, 0], datos[i, 1] };

                salida.inputs = new double[] { N1.output, N2.output };

                Console.WriteLine("{0} XOR {1} = {2}", datos[i, 0], datos[i, 1], salida.output);


                salida.error = obtener.salidDev(salida.output) * (resul[i] - salida.output);
                salida.peso2();


                N1.error = obtener.salidDev(N1.output) * salida.error * salida.weights[0];
                N2.error = obtener.salidDev(N2.output) * salida.error * salida.weights[1];

                N1.peso2();
                N2.peso2();
            }

            if (contador < 5)
                goto Var;
            Console.ReadLine();
        }

   
        

     
}

}
            
        
