using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Wine
    {
        public int Id { get; set; }

        // El nombre del vino, requerido
        public string Name { get; set; } = string.Empty;


        // Variedad del vino (ej: Cabernet Sauvignon)
        public string Variety { get; set; } = string.Empty;

        // Año de cosecha, debe ser un valor válido
        public int Year { get; set; }

        // Región de origen (ej: Mendoza, La Rioja)
        public string Region { get; set; } = string.Empty;

        // Cantidad disponible en stock, debe ser mayor o igual a 0
        private int _stock;
        public int Stock
        {
            get => _stock;
            set
            {
                if (value < 0) throw new ArgumentException("El stock no puede ser negativo.");
                _stock = value;
            }
        }

        // Fecha de registro del vino en el sistema
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Método para añadir stock
        public void AddStock(int amount)
        {
            if (amount <= 0) throw new ArgumentException("La cantidad a añadir debe ser mayor a 0.");
            Stock += amount;
        }

        // Método para reducir stock
        public void RemoveStock(int amount)
        {
            if (amount <= 0) throw new ArgumentException("La cantidad a reducir debe ser mayor a 0.");
            if (Stock - amount < 0) throw new InvalidOperationException("No hay suficiente stock disponible.");
            Stock -= amount;
        }
    }
}
