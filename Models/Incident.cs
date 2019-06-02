using System;


namespace SAPWS.Models
{
    public class Incident
    {
        private int _idIncident;
        private string _code;
        private string _name;
        private string _description;
        private DateTime _incidenceDate;

        public int IdIncident
        {
            get
            {
                return this._idIncident;
            }
            set
            {
                this._idIncident = value;
            }
        }

        public string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

        public DateTime IncidenceDate
        {
            get
            {
                return this._incidenceDate;
            }
            set
            {
                this._incidenceDate = value;
            }
        }
    }
}