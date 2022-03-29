using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TpeParameters.Helpers;

namespace TpeParameters.Model
{
    public class ParameterItem
    {
        public ParameterItem(int id, string index, string name, int address,
            string variableName, double value, ParameterConfiguration configuration,
            ParameterValueDescription valueDescription, ParameterInfo info)
        {
            _id = id;
            _index = index;
            _name = name;
            _address = address;
            _variableName = variableName;

            _configuration = configuration;
            _valueDescription = valueDescription;
            _info = info;

            SetUnsValue(value);
        }

        public ParameterItem(ParameterItem sourceParameter)
        {
            this._id = sourceParameter.Id;
            this._index = sourceParameter.Index;
            this._name = sourceParameter.Name;
            this._address = sourceParameter.Address;
            this._variableName = sourceParameter.VariableName;

            this._configuration = sourceParameter.Configuration;
            this._valueDescription = sourceParameter.ValueDescription;
            this._info = sourceParameter.Info;

            this.SetUnsValue(sourceParameter.Value);
        }

        #region Fields

        private int _id;
        private string _index;
        private string _name;
        private int _address;
        private string _variableName;
        private double _value;
        private ParameterConfiguration _configuration;
        private ParameterValueDescription _valueDescription;
        private ParameterInfo _info;

        #endregion

        private double TranformValue(double value)
        {
            if (_valueDescription != null)
            {
                return value * _valueDescription.Coefficient;
            }

            return value;
        }

        public void SetUnsValue(double unsValue)
        {
            // делаем преобразования знакового числа
            if (_valueDescription.ValueType == ParamValueTypes.Int)
            {
                if (unsValue > 32767)
                {
                    Int16 iv = (Int16)unsValue;
                    unsValue = (double)iv;
                }
            }

            // проверяем значение прежде чем присвоить его
            if (unsValue >= _valueDescription.Minimum && unsValue <= _valueDescription.Maximum)
                _value = TranformValue(unsValue);
        }

        public void SetDoubleValue(double doubleValue)
        {
            // проверяем значение прежде чем присвоить его
            if (doubleValue >= _valueDescription.Minimum && doubleValue <= _valueDescription.Maximum)
                _value = doubleValue;
        }

        #region Properties

        public int Id
        {
            get { return _id; }
        }

        public string Index
        {
            get { return _index; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int Address
        {
            set { _address = Address; }
            get { return _address; }
        }

        public string VariableName
        {
            get { return _variableName; }
        }

        // нужен пересчет значения в зависимости от конфигурации
        public double Value
        {
            get { return _value; }
        }

        public ParameterConfiguration Configuration
        {
            get { return _configuration; }
        }

        public ParameterValueDescription ValueDescription
        {
            get { return _valueDescription; }
        }

        public ParameterInfo Info
        {
            get { return _info; }
        }

        #endregion

    }

    public class ParameterConfiguration
    {
        public ParameterConfiguration(ParamTypes paramType, ParamAppointments appointment, bool canEdit, bool isChosen)
        {
            _paramType = paramType;
            _appointment = appointment;
            _canEdit = canEdit;
            _isChosen = isChosen;
        }

        private ParamTypes _paramType;
        private ParamAppointments _appointment;
        private bool _canEdit;
        private bool _isChosen;

        public ParamTypes ParamType
        {
            get { return _paramType; }
        }

        public ParamAppointments Appointment
        {
            get { return _appointment; }
        }

        /// <summary>
        /// Указывает, что параметр может быть редактирован
        /// </summary>
        public bool CanEdit
        {
            get { return _canEdit; }
        }

        /// <summary>
        /// Параметры с этим флагом отображаются в панели "избранных параметров"
        /// </summary>
        public bool IsChosen
        {
            get { return _isChosen; }
        }
    }

    public class ParameterValueDescription
    {
        public ParameterValueDescription(double minimum, double maximum,
            double defValue, string unit, double coefficient, ParamValueTypes valueType,
            List<ParameterFieldItem> fields)
        {
            _coefficient = coefficient;
            _minimum = minimum;
            _maximum = maximum;
            _default = defValue;
            _unit = unit;            
            _valueType = valueType;
            _fields = fields;
        }

        #region Fields

        private double _minimum;
        private double _maximum;
        private double _default;
        private string _unit;

        private double _coefficient;

        private ParamValueTypes _valueType;
        private List<ParameterFieldItem> _fields;

        #endregion

        #region Properties

        /// <summary>
        /// Минимальное значение параметра
        /// </summary>
        public double Minimum
        {
            get { return _minimum; }
        }

        /// <summary>
        /// Максимальное значение параметра
        /// </summary>
        public double Maximum
        {
            get { return _maximum; }
        }

        /// <summary>
        /// Значение параметра по умолчанию
        /// </summary>
        public double Default
        {
            get { return _default; }
        }

        /// <summary>
        /// Единица измерения
        /// </summary>
        public string Unit
        {
            get { return _unit; }
        }

        /// <summary>
        /// Подстроечный коэфициент
        /// </summary>
        public double Coefficient
        {
            get { return _coefficient; }
        }

        public ParamValueTypes ValueType
        {
            get { return _valueType; }
        }

        public List<ParameterFieldItem> Fields
        {
            get { return _fields; }
        }

        #endregion

    }

    public class ParameterFieldItem
    {
        public ParameterFieldItem(int bitValue, string description, string specialDescription)
        {
            _bitValue = bitValue;
            _description = description;
            _specialDescription = specialDescription;
        }

        private int _bitValue;
        private string _description;
        private string _specialDescription;

        public int BitValue
        {
            get { return _bitValue; }
        }

        public string Description
        {
            get { return _description; }
        }

        public string SpecialDescription
        {
            get { return _specialDescription; }
        }

    }

    public class ParameterInfo
    {
        public ParameterInfo(string description, string comment)
        {
            _description = description;
            _comment = comment;
        }

        private string _description;
        private string _comment;

        public string Description
        {
            get { return _description; }
        }

        public string Comment
        {
            get { return _comment; }
        }
    }
}
