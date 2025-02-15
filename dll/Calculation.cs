
namespace dll
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
    public class Calculation
    {
        public static int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
            int result = 0;
            List<double> materialTypeList = new() { 0.3, 0.12 };
            List<double> productTypeList = new() { 1.1, 2.5, 8.43 };

            if (productType < 1 || productType > 3) throw new InvalidInputException("Тип продукции должен быть выбран от 1 до 3.");
            else if (materialType < 1 || materialType > 2) throw new InvalidInputException("Тип материала должен быть выбран от 1 до 2.");
            else if (count <= 0) throw new InvalidInputException("Количество продукции не должно быть меньше 1.");
            else if (width <= 0 || length <= 0) throw new InvalidInputException("Ширина и длина продукции не должны быть меньше 1.");
            else
            {
                double quantitWithoutDefects = (length * width) * count * productTypeList[productType - 1];
                return result = (int)Math.Ceiling(quantitWithoutDefects + quantitWithoutDefects * (materialTypeList[materialType - 1] / 100));
            }
        }
    }        
}
