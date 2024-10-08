using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatosComida.Models
{
    public class Platos : INotifyPropertyChanged
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id == value)
                    return;
                _Id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }
        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                if (_Nombre == value)
                    return;
                _Nombre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nombre)));
            }
        }
        private float _Costo;
        public float Costo
        {
            get { return _Costo; }
            set
            {
                if (_Costo == value)
                    return;
                _Costo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Costo)));
            }
        }
        private string _Ingredientes;
        public string Ingredientes
        {
            get { return _Ingredientes; }
            set
            {
                if (_Ingredientes == value)
                    return;
                _Ingredientes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ingredientes)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
