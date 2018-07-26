using LucasRosinelli.Rate.Domain.Entities;
using LucasRosinelli.Rate.SharedKernel;
using LucasRosinelli.Rate.SharedKernel.Contracts;
using LucasRosinelli.Rate.SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.XPath;

namespace LucasRosinelli.Rate.Infrastructure.Persistence.DataContext
{
    public class RateDataContextFromEcbXml : IDataContext
    {
        #region IDataContext implementation

        #region Properties

        /// <summary>
        /// Gets if data was successfully loaded or not.
        /// </summary>
        public bool IsLoaded { get; private set; }
        /// <summary>
        /// Gets if data is expired or not.
        /// </summary>
        public bool IsExpired
        {
            get
            {
                return DateTime.Now > this._nextUpdate;
            }
        }
        /// <summary>
        /// Gets reference statistics data.
        /// </summary>
        public ICollection<ReferenceStatistic> ReferenceStatistics
        {
            get
            {
                this.Load();

                return this._referenceStatistics;
            }
            set
            {
                if (value == null)
                {
                    _referenceStatistics = new HashSet<ReferenceStatistic>();
                }
                else
                {
                    this._referenceStatistics = new HashSet<ReferenceStatistic>(value);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Disposes objects.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Loads data from source.
        /// </summary>
        public void Load()
        {
            if (this.IsExpired || !this.IsLoaded)
            {
                var success = false;

                try
                {
                    var mustClear = true; // mustClear is used to keep data even expired and some exception occurs
                    var document = new XPathDocument(this._ecbXmlUrl);
                    var navigator = document.CreateNavigator();
                    navigator.MoveToRoot();
                    var elements = navigator.SelectDescendants(XPathNodeType.Element, false);
                    while (elements.MoveNext())
                    {
                        if (elements.Current.Name.Equals(this.ElementNameCube, StringComparison.InvariantCultureIgnoreCase))
                        {
                            var currency = elements.Current.GetAttribute(this.AttributeNameCurrency, string.Empty);
                            var rateText = elements.Current.GetAttribute(this.AttributeNameRate, string.Empty);

                            if (!string.IsNullOrEmpty(currency) && !string.IsNullOrEmpty(rateText))
                            {
                                decimal rate;
                                if (decimal.TryParse(rateText, NumberStyles.Currency, RateConstants.CultureInfoEnglish, out rate))
                                {
                                    var referenceStatistic = new ReferenceStatistic(currency, rate);
                                    if (referenceStatistic.Register())
                                    {
                                        if (mustClear)
                                        {
                                            this._referenceStatistics.Clear();
                                            mustClear = false;
                                        }
                                        this._referenceStatistics.Add(referenceStatistic);
                                    }
                                }
                            }
                        }
                    }

                    success = true;
                }
                catch (Exception)
                {
                    var domainNotification = new DomainNotification(RateConstants.AssertDataContextLoadFail, "Failed loading data.");
                }

                if (success)
                {
                    this.IsLoaded = true;
                    this.RefreshNextUpdate();
                }
            }
        }

        /// <summary>
        /// Saves changes.
        /// </summary>
        /// <returns>Records affected.</returns>
        public int SaveChanges()
        {
            return 0;
        }

        #endregion

        #endregion

        #region Constants

        /// <summary>
        /// Element name cube.
        /// </summary>
        private readonly string ElementNameCube = "cube";
        /// <summary>
        /// Cube attribute name currency.
        /// </summary>
        private readonly string AttributeNameCurrency = "currency";
        /// <summary>
        /// Cube attribute name rate.
        /// </summary>
        private readonly string AttributeNameRate = "rate";

        #endregion

        #region Fields

        /// <summary>
        /// Domain notifications.
        /// </summary>
        private readonly IHandler<DomainNotification> _notifications;
        /// <summary>
        /// Expiration time read from configurations.
        /// </summary>
        private int _expirationTimeInMinutes;
        /// <summary>
        /// European Central Bank XML URL read from configurations.
        /// </summary>
        private string _ecbXmlUrl;
        /// <summary>
        /// Next update of data.
        /// </summary>
        private DateTime _nextUpdate;
        /// <summary>
        /// Reference statistics data.
        /// </summary>
        private HashSet<ReferenceStatistic> _referenceStatistics;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes data context.
        /// </summary>
        public RateDataContextFromEcbXml(IHandler<DomainNotification> notifications)
        {
            this._expirationTimeInMinutes = 2;
            this._ecbXmlUrl = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
            this._nextUpdate = DateTime.Now;
            _referenceStatistics = new HashSet<ReferenceStatistic>();

            this.IsLoaded = false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Refreshes next update.
        /// </summary>
        private void RefreshNextUpdate()
        {
            this._nextUpdate = DateTime.Now.AddMinutes(this._expirationTimeInMinutes);
        }

        #endregion
    }
}