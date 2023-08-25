using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlgorithmRecreactionWpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OriginalAlgorithm();

            T_values.Sort((x,y) => x.Unit.CompareTo(y.Unit));
            mainDatagrid.ItemsSource = T_values;
            Debug.WriteLine(T_values.Count);
        }

        public class MultiplicationTableElem
        {
            public MultiplicationTableElem(string calculationUnit, int power, string baseUnit)
            {
                this.calculationUnit = calculationUnit;
                this.power = power;
                this.baseUnit = baseUnit;
            }
            private string calculationUnit;
            private int power;
            private string baseUnit;
            public string CalculationUnit { get { return calculationUnit; } }
            public int Power { get { return power; } }
            public string BaseUnit { get { return baseUnit; } }
            public string Name { get { return calculationUnit + " <--> " + baseUnit; } }
        }

        public class ConvertionTableElem
        {
            public ConvertionTableElem(string originalUnit, double coef, string resultingUnit)
            {
                this.originalUnit = originalUnit;
                this.coef = coef;
                this.resultingUnit = resultingUnit;
            }
            private string originalUnit;
            private double coef;
            private string resultingUnit;
            public string OriginalUnit { get { return originalUnit; } }
            public double Coef { get { return coef; } }
            public string ResultingUnit { get { return resultingUnit; } }
            public string Name { get { return originalUnit + " --> " + resultingUnit; } }

        }

        public class TotalFinalConsumptionTableElem
        {
            public TotalFinalConsumptionTableElem(int year, string unit, double value)
            {
                this.parameter = "TFC";
                this.resource = "Природный газ";
                this.year = year;
                this.unit = unit;
                this.value = value;
            }
            private string parameter;
            private string resource;
            private int year;
            private string unit;
            private double value;
            /// <summary>
            /// показатель
            /// </summary>
            public string Parameter { get { return parameter; } set { parameter = value; } }
            /// <summary>
            /// ресурс
            /// </summary>
            public string Resource { get { return resource; } set { resource = value; } }
            /// <summary>
            /// год
            /// </summary>
            public int Year { get { return year;} set { year = value; } }
            /// <summary>
            /// единица измерения
            /// </summary>
            public string Unit { get { return unit; } set { unit = value; } }
            /// <summary>
            /// значение
            /// </summary>
            public double Value { get { return value; } set { this.value = value; } }
        }

        public List<MultiplicationTableElem> T_multiplication = new List<MultiplicationTableElem>()
        {
            new MultiplicationTableElem("Gft3ng", -9, "ft3ng"),
            new MultiplicationTableElem("Gtce", -9, "tce"),
            new MultiplicationTableElem("Gtoe", -9, "toe"),
            new MultiplicationTableElem("MMbtu", -6, "btu"),
            new MultiplicationTableElem("Mj", -6, "j"),
            new MultiplicationTableElem("Kboe", -3, "boe"),
            new MultiplicationTableElem("Mtoe", -6, "toe"),
            new MultiplicationTableElem("Twh", -12, "wh"),
            new MultiplicationTableElem("Ktoe", -3, "toe"),
            new MultiplicationTableElem("Gj", -9, "j"),
            new MultiplicationTableElem("Mboe", -6, "boe"),
            new MultiplicationTableElem("Mtce", -6, "tce"),
            new MultiplicationTableElem("Gm3ng", -9, "m3ng"),
            new MultiplicationTableElem("Bboe", -9, "boe"),
            new MultiplicationTableElem("Qbtu", -15, "btu"),
            new MultiplicationTableElem("Mm3ng", -6, "m3ng"),
            new MultiplicationTableElem("Mft3ng", -6, "ft3ng"),
            new MultiplicationTableElem("Gwh", -9, "wh"),
        };

        public List<ConvertionTableElem> T_convertation = new List<ConvertionTableElem>()
        {
            new ConvertionTableElem("Mtce", 751.4768963, "Mm3ng"),
            new ConvertionTableElem("Gft3ng", 0.301277062, "Twh"),
            new ConvertionTableElem("MMbtu", 1055.060005, "Mj"),
            new ConvertionTableElem("Bboe", 0.580005, "Qbtu"),
            new ConvertionTableElem("Gtoe", 1.4285714, "Gtce"),
            new ConvertionTableElem("Gj", 0.000277778, "Gwh"),
            new ConvertionTableElem("Ktoe", 6.8419054, "Kboe"),
            new ConvertionTableElem("Gm3ng", 35.958043, "Gft3ng"),
        };

        public List<TotalFinalConsumptionTableElem> T_values = new List<TotalFinalConsumptionTableElem>()
        {
            new TotalFinalConsumptionTableElem(2017, "Mtoe", 148.67),
            new TotalFinalConsumptionTableElem(2018, "Mtoe", 149.33),
            new TotalFinalConsumptionTableElem(2019, "Mtoe", 150.00),
            new TotalFinalConsumptionTableElem(2020, "Mtoe", 150.67),
            new TotalFinalConsumptionTableElem(2021, "Mtoe", 151.33),
            /*
            new TotalFinalConsumptionTableElem(2017, "Gwh", 172903.22),
            new TotalFinalConsumptionTableElem(2018, "Gwh", 173670.80),
            new TotalFinalConsumptionTableElem(2019, "Gwh", 174450.01),
            new TotalFinalConsumptionTableElem(2020, "Gwh", 175229.22),
            new TotalFinalConsumptionTableElem(2021, "Gwh", 175996.80),
            new TotalFinalConsumptionTableElem(2017, "Twh", 1729.03),
            new TotalFinalConsumptionTableElem(2018, "Twh", 1736.71),
            new TotalFinalConsumptionTableElem(2019, "Twh", 1744.50),
            new TotalFinalConsumptionTableElem(2020, "Twh", 1752.29),
            new TotalFinalConsumptionTableElem(2021, "Twh", 1759.97),
            */
        };

        //public Tuple<int, string, double>[,,] T_values_array = new string[1, 1, 1] { { { "2017", "Mtoe", "148.67"} } };

        public void OriginalAlgorithm()
        {
            /*Получить P_indicators – параметр запуска расчета, массив записей таблицы T_indicators;*/
            List<string> P_indicators = new List<string>() { "TFC" };
            /*Получить P_resources – параметр запуска расчета, массив записей таблицы T_resources;*/
            List<string> P_resources = new List<string>() { "Природный газ" };
            /*Получить P_years – параметра запуска расчета, массив записей таблицы T_years;*/
            List<int> P_years = new List<int>() { 2017, 2018, 2019, 2020, 2021 };

            /*5. Для очередного показателя I из P_indicators:*/
            for (int i = 0; i < P_indicators.Count; i++)
            {
                /*5.1. Для очередного ресурса R из P_resources:*/
                for (int r = 0; r < P_resources.Count; r++)
                {
                    /*5.1.1. Для очередного года Y из P_years:*/
                    for (int y = 0; y < P_years.Count; y++)
                    {
                        /*5.1.1.1. Получить M_values – массив записей T_values, каждая из которых удовлетворяет
                        условию [[Значение поля «Показатель» = I] и [Значение поля «Ресурс» = R] и [Значение
                        поля «Год» = Y]];*/
                        List<TotalFinalConsumptionTableElem> M_values = new List<TotalFinalConsumptionTableElem>();
                        foreach (var item in T_values)
                        {
                            if (item.Parameter == P_indicators[i])
                                if (item.Resource == P_resources[r])
                                    if (item.Year == P_years[y])
                                        M_values.Add(item);
                        }
                        /*5.1.1.2. Получить M_calculated – массив записей T_multiplication, каждая из которых
                        удовлетворяет условию [[Значение поля «Базовая ЕИ» содержится в поле «Единица
                        измерения» какой-либо записи M_values] и [Значение поля «Расчетная ЕИ» не
                        содержится в поле «Единица измерения» записей M_values]];*/
                        List<MultiplicationTableElem> M_calculated = new List<MultiplicationTableElem>();
                        foreach (var itemMult in T_multiplication)
                        {
                            foreach (var itemMval in M_values)
                            {
                                if (itemMult.BaseUnit == itemMval.Unit)
                                {
                                    bool secondCheck = true;
                                    foreach (var itemMvalSecondCheck in M_values)
                                    {
                                        if (itemMult.CalculationUnit == itemMvalSecondCheck.Unit)
                                        {
                                            secondCheck = false;
                                            break;
                                        }
                                    }
                                    if (secondCheck)
                                        M_calculated.Add(itemMult);
                                }
                            }
                        }
                        /*5.1.1.3.Получить M_based – массив записей T_multiplication, каждая из которых
                        удовлетворяет условию[[Значение поля «Расчетная ЕИ» содержится в поле «Единица
                        измерения» какой - либо записи M_values] и[Значение поля «Базовая ЕИ» не содержится
                        в поле «Единица измерения» записей M_values]];*/
                        List<MultiplicationTableElem> M_based = new List<MultiplicationTableElem>();
                        foreach (var itemMult in T_multiplication)
                        {
                            foreach (var itemMval in M_values)
                            {
                                if (itemMult.CalculationUnit == itemMval.Unit)
                                {
                                    bool secondCheck = true;
                                    foreach (var itemMvalSecondCheck in M_values)
                                    {
                                        if (itemMult.BaseUnit == itemMvalSecondCheck.Unit)
                                        {
                                            secondCheck = false;
                                            break;
                                        }
                                    }
                                    if (secondCheck)
                                        M_based.Add(itemMult);
                                }
                            }
                        }
                        /*5.1.1.4. Получить M_result – массив записей T_convertation, каждая из которых
                        удовлетворяет условию [[Значение поля «Исходная ЕИ» содержится в поле «Единица
                        измерения» какой-либо записи M_values] и [Значение поля «Результирующая ЕИ» не
                        содержится в поле «Единица измерения» записей M_values]];*/
                        List<ConvertionTableElem> M_result = new List<ConvertionTableElem>();
                        foreach (var itemConv in T_convertation)
                        {
                            foreach (var itemMval in M_values)
                            {
                                if (itemConv.OriginalUnit == itemMval.Unit)
                                {
                                    bool secondCheck = true;
                                    foreach (var itemMvalSecondCheck in M_values)
                                    {
                                        if (itemConv.ResultingUnit == itemMvalSecondCheck.Unit)
                                        {
                                            secondCheck = false;
                                            break;
                                        }
                                    }
                                    // FIX START
                                    foreach (var itemDublicationCheck in M_calculated) 
                                    {
                                        if (itemConv.ResultingUnit == itemDublicationCheck.CalculationUnit)
                                        {
                                            secondCheck = false;
                                            break;
                                        }
                                    }
                                    // FIX END
                                    if (secondCheck)
                                        M_result.Add(itemConv);
                                }
                            }
                        }
                        /*5.1.1.5. Если [[M_calculated пусто] и [M_based пусто] и [M_result пусто]], то перейти в 5.1.2,
                        иначе перейти в 5.1.1.5.1:*/
                        if (!(M_calculated.Count == 0 && M_based.Count == 0 && M_result.Count == 0))
                        {
                            /*5.1.1.5.1. Если [M_calculated пусто], то перейти в 5.1.1.5.2, иначе перейти в 5.1.1.5.1.1:*/
                            if (!(M_calculated.Count == 0))
                            {
                                /*5.1.1.5.1.1. Для каждой записи M_values, у которой значение поля «Единица
                                измерения» содержится в поле «Базовая ЕИ» записей M_calculated, рассчитать
                                значения в единицах измерения, которые содержатся в поле «Расчетная ЕИ»
                                соответствующих записей M_calculated по формуле: [Значение в расчетной ЕИ
                                = Значение в базовой ЕИ * 10^E];*/
                                List<TotalFinalConsumptionTableElem> values = new List<TotalFinalConsumptionTableElem>();
                                foreach (var itemMval in M_values)
                                {
                                    foreach (var itemCalc in M_calculated)
                                    {
                                        if (itemMval.Unit == itemCalc.BaseUnit)
                                        {
                                            values.Add(
                                                new TotalFinalConsumptionTableElem(
                                                    P_years[y], 
                                                    itemCalc.CalculationUnit, 
                                                    itemMval.Value * Math.Pow(10.0, itemCalc.Power)
                                                    )
                                                );
                                        }
                                    }
                                }
                                /*5.1.1.5.1.2.Записать в T_values для I, R, Y все значения, рассчитанные в
                                расчетных единицах измерения, перейти в 5.1.1.5.2;*/
                                T_values.AddRange(values);

                            }
                            /*5.1.1.5.2. Если [M_based пусто], то перейти в 5.1.1.5.3, иначе перейти в 5.1.1.5.2.1*/
                            if (!(M_based.Count == 0))
                            {
                                /*5.1.1.5.2.1.Для каждой записи M_values, у которой значение поля «Единица
                                измерения» содержится в поле «Расчетная ЕИ» записей M_based, рассчитать
                                значения в единицах измерения, которые содержатся в поле «Базовая ЕИ»
                                соответствующих записей M_based по формуле: [Значение в базовой ЕИ =
                                Значение в расчетной ЕИ * 10^(–E)];*/
                                List<TotalFinalConsumptionTableElem> values = new List<TotalFinalConsumptionTableElem>();
                                foreach (var itemMval in M_values)
                                {
                                    foreach (var itemBased in M_based)
                                    {
                                        if (itemMval.Unit == itemBased.CalculationUnit)
                                        {
                                            values.Add(
                                                new TotalFinalConsumptionTableElem(
                                                    P_years[y], 
                                                    itemBased.BaseUnit, 
                                                    itemMval.Value * Math.Pow(10.0, -itemBased.Power)
                                                    )
                                                );
                                        }
                                    }
                                }
                                /*5.1.1.5.2.2. Записать в T_values для I, R, Y все значения, рассчитанные в базовых
                                единицах измерения, перейти в 5.1.1.5.3;*/
                                T_values.AddRange(values);
                            }
                            /*5.1.1.5.3. Если [M_result пусто], то перейти в 5.1.1.1, иначе перейти в 5.1.1.5.3.1:*/
                            if (!(M_result.Count == 0))
                            {
                                /*5.1.1.5.3.1.Для каждой записи M_values, у которой значение поля «Единица
                                измерения» содержится в поле «Исходная ЕИ» записей M_result, рассчитать
                                значения в единицах измерения, которые содержатся в поле «Результирующая
                                ЕИ» соответствующих записей M_result по формуле: [Значение в
                                результирующей ЕИ = Значение в исходной ЕИ * K];*/
                                List<TotalFinalConsumptionTableElem> values = new List<TotalFinalConsumptionTableElem>();
                                foreach (var itemMval in M_values)
                                {
                                    foreach (var itemMres in M_result)
                                    {
                                        if (itemMval.Unit == itemMres.OriginalUnit)
                                        {
                                            values.Add(
                                                new TotalFinalConsumptionTableElem(
                                                    P_years[y],
                                                    itemMres.ResultingUnit,
                                                    itemMval.Value * itemMres.Coef
                                                    )
                                                );
                                        }
                                    }
                                }
                                /*5.1.1.5.3.2. Записать в T_values для I, R, Y все значения, рассчитанные в
                                результирующих единицах измерения, перейти в 5.1.1.1;*/
                                T_values.AddRange(values);
                            }
                            y--; // переход в 5.1.1.1
                        }
                        /*5.1.2. Если по всем Y из P_years расчет завершен, то перейти в 5.2, иначе перейти в 5.1.1;*/
                    }
                }
            }
        }
    }
}
