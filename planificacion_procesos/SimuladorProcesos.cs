using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planificacion_procesos
{
    class SimuladorProcesos
    {
        private int[] _procesos;
        private Random _generador;
        private int _nProcesos;

        public int[] Procesos
        {
            get { return _procesos; }
        }


        public SimuladorProcesos(int nProcesos, int tMaximo)
        {
            _generador = new Random(DateTime.Now.Millisecond);
            _procesos = new int[nProcesos];
            _nProcesos = _procesos.Length;

            for (int i = 0; i < nProcesos; i++)
            {
                _procesos[i] = _generador.Next(1,tMaximo);
            }
        }

        public string FirstComeFirstServed()
        {
            int[] sumaProcesos = getSumasParciales(_procesos);
            return getInfoAlgoritmo(sumaProcesos);
        }

        public string SmallestJobFirst()
        {
            //Copiando vector principal
            int[] arrayOrdenado = _procesos;
            //Ordenando vector copiado en forma ascendente
            int auxili;
            int j;
            for (int i = 0; i < arrayOrdenado.Length; i++)
            {
                auxili = arrayOrdenado[i];
                j = i - 1;
                while (j >= 0 && arrayOrdenado[j] > auxili)
                {
                    arrayOrdenado[j + 1] = arrayOrdenado[j];
                    j--;
                }
                arrayOrdenado[j + 1] = auxili;
            }

            int[] sumaProcesos = getSumasParciales(arrayOrdenado);
            return getInfoAlgoritmo(sumaProcesos);
        }

        public string LargestJobFirst()
        {
            int[] array = _procesos;
            var copiaOrdenada = array.OrderByDescending(x => x).ToArray();
            int[] sumaProcesos = getSumasParciales(copiaOrdenada);
            return getInfoAlgoritmo(sumaProcesos);
        }

        public string RobinRound()
        {
            return "";
        }

        public int[] getSumasParciales(int[] vector)
        {

            int[] vectorSumado = new int[vector.Length+1];
            vectorSumado[0] = 0;
            for (int i = 1; i < vectorSumado.Length; i++)
            {
                vectorSumado[i] = vectorSumado[i - 1] + vector[i - 1];
            }
            return vectorSumado;
        }

        public string getInfoAlgoritmo(int[] vectorSumas)
        {
            int tiempoMaximoEspera;
            double tiempoEsperaTotal;
            double tiempoRespuestaTotal;

            tiempoMaximoEspera = vectorSumas[_nProcesos];

            tiempoEsperaTotal = 0;
            for (int i = 0; i < _nProcesos - 1; i++)
            {
                tiempoEsperaTotal += vectorSumas[i];
            }
            tiempoEsperaTotal /= _nProcesos;

            tiempoRespuestaTotal = 0;
            for (int i = 1; i < _nProcesos; i++)
            {
                tiempoRespuestaTotal += vectorSumas[i];
            }
            tiempoRespuestaTotal /= _nProcesos;

            return "Cmax:\t" + tiempoMaximoEspera + Environment.NewLine +
                   "Tet:\t" + tiempoEsperaTotal + Environment.NewLine +
                   "Trt:\t" + tiempoRespuestaTotal + Environment.NewLine;
        }
    }
}
