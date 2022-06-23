using SaeApp.DataAccess.Modules.Inventory;
using SaeApp.Model.Modules.Inventory;
using SaeApp.Model.Modules.System.Secutiry;
using SaeApp.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaeApp.View.Modules.Inventory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetail : ContentPage, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Attributes

        string _internalcode;
        string _name;
        string _description;
        decimal _costPrice;
        decimal _profitPercentage;
        decimal _unitPrice;
        decimal _profitAmount;
        decimal _sellPrice;
        DateTime _admissionDate = DateTime.Today;
        DateTime _modificationDate = DateTime.Today;
        Brand _brandSelected;
        List<Brand> _brandList = new List<Brand>();

        #endregion

        #region Propierties

        public string Internalcode
        {
            get { return _internalcode; }
            set
            {
                _internalcode = value;
                OnPropertyChanged("Internalcode");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }
        public decimal CostPrice
        {
            get { return _costPrice; }
            set
            {
                _costPrice = value;
                OnPropertyChanged("CostPrice");
            }
        }
        public decimal ProfitPercentage
        {
            get { return _profitPercentage; }
            set
            {
                _profitPercentage = value;
                OnPropertyChanged("ProfitPercentage");
            }
        }
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                _unitPrice = value;
                OnPropertyChanged("UnitPrice");
            }
        }
        public decimal ProfitAmount
        {
            get { return _profitAmount; }
            set
            {
                _profitAmount = value;
                OnPropertyChanged("ProfitAmount");
            }
        }
        public decimal SellPrice
        {
            get { return _sellPrice; }
            set
            {
                _sellPrice = value;
                OnPropertyChanged("SellPrice");
            }
        }
        public DateTime AdmissionDate
        {
            get { return _admissionDate; }
            set
            {
                _admissionDate = value;
                OnPropertyChanged("AdmissionDate");
            }
        }
        public DateTime ModificationDate
        {
            get { return _modificationDate; }
            set
            {
                _modificationDate = value;
                OnPropertyChanged("ModificationDate");
            }
        }
        public Brand BrandSelected
        {
            get { return _brandSelected; }
            set
            {
                _brandSelected = value;
                OnPropertyChanged("BrandSelected");
            }
        }
        public List<Brand> BrandList
        {
            get { return _brandList; }
            set
            {
                _brandList = value;
                OnPropertyChanged("BrandList");
            }
        }
        public Item ObjItem { get; set; }

        #endregion

        #region Constructors

        public ItemDetail()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public ItemDetail(Resource objResource, object objSelected)
        {
            InitializeComponent();

            PageLoad(objResource, objSelected);
            this.BindingContext = this;
        }

        #endregion

        #region Methods

        async void PageLoad(Resource objResource, object objSelected)
        {
            try
            {
                BrandDAO database = await BrandDAO.Instance;

                List<Brand> objBrandList = await database.GetItemsAsync().ConfigureAwait(false);
                if (objBrandList.Count > 0)
                    this.BrandList = objBrandList;

                if (objSelected != null)
                {
                    this.ObjItem = objSelected as Item;

                    this.Internalcode = this.ObjItem.Internalcode;
                    this.Name = this.ObjItem.Name;
                    this.Description = this.ObjItem.Description;
                    this.CostPrice = this.ObjItem.CostPrice;
                    this.ProfitPercentage = this.ObjItem.ProfitPercentage;
                    this.UnitPrice = this.ObjItem.UnitPrice;
                    this.ProfitAmount = this.ObjItem.ProfitAmount;
                    this.SellPrice = this.ObjItem.SellPrice;
                    this.AdmissionDate = this.ObjItem.AdmissionDate;
                    this.ModificationDate = this.ObjItem.ModificationDate;

                    
                    if (objBrandList.Count > 0)
                    {
                        if (this.ObjItem.IdBrand > 0)
                        {
                            Brand objBrand = objBrandList.Find(x => x.IdBrand == this.ObjItem.IdBrand);
                            if (objBrand != null)
                                this.BrandSelected = objBrand;
                        }
                    }
                    else
                    {
                        objBrandList.Add(new Brand
                        {
                            IdBrand = 1,
                            Name = "Huda Beauty",
                            IdCompany = 1
                        });
                        objBrandList.Add(new Brand
                        {
                            IdBrand = 2,
                            Name = "Brand",
                            IdCompany = 1
                        });

                        if (objBrandList.Count > 0)
                        {
                            Brand objBrand = objBrandList.Find(x => x.IdBrand == this.ObjItem.IdBrand);
                            if (objBrand != null)
                                this.BrandSelected = objBrand;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert("Ha ocurrido un error: " + exc.Message);
            }
        }

        async void btnEdit_Clicked(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exc)
            {
                Tools.DisplayAlert("Ha ocurrido un error: " + exc.Message);
            }
        }

        async void btnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                var objItem = (ItemDetail)BindingContext;
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert("Ha ocurrido un error: " + exc.Message);
            }
        }

        async void btnClose_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert("Ha ocurrido un error: " + exc.Message);
            }
        }

        #endregion
    }
}