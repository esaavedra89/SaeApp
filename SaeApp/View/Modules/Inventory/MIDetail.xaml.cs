using SaeApp.Model.Modules.Inventory;
using SaeApp.Model.Modules.System.Entity;
using SaeApp.Model.Modules.System.Security;
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
    public partial class MIDetail : ContentPage, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Attributes

        decimal _number;
        StateEntity _stateEntitySelected;
        List<StateEntity> _stateEntityList = new List<StateEntity>();
        InventoryMovementType _inventoryMovementTypeSelected;
        List<InventoryMovementType> _inventoryMovementTypeList = new List<InventoryMovementType>();
        User _responsibleUserSelected;
        List<User> _responsibleUserList = new List<User>();
        InventoryMovementMotive _inventoryMovementMotiveSelected;
        List<InventoryMovementMotive> _inventoryMovementMotiveList = new List<InventoryMovementMotive>();
        string _comments;
        DateTime _admissionDate = DateTime.Today;
        DateTime _modificationDate = DateTime.Today;
        List<InventoryMovementItem> _inventoryMovementItemList = new List<InventoryMovementItem>();
        #endregion

        #region Propierties

        public decimal Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }
        public StateEntity StateEntitySelected
        {
            get { return _stateEntitySelected; }
            set
            {
                _stateEntitySelected = value;
                OnPropertyChanged("StateEntitySelected");
            }
        }
        public List<StateEntity> StateEntityList
        {
            get { return _stateEntityList; }
            set
            {
                _stateEntityList = value;
                OnPropertyChanged("StateEntityList");
            }
        }
        public InventoryMovementType InventoryMovementTypeSelected
        {
            get { return _inventoryMovementTypeSelected; }
            set
            {
                _inventoryMovementTypeSelected = value;
                OnPropertyChanged("InventoryMovementTypeSelected");
            }
        }
        public List<InventoryMovementType> InventoryMovementTypeList
        {
            get { return _inventoryMovementTypeList; }
            set
            {
                _inventoryMovementTypeList = value;
                OnPropertyChanged("InventoryMovementTypeList");
            }
        }
        public User ResponsibleUserSelected
        {
            get { return _responsibleUserSelected; }
            set
            {
                _responsibleUserSelected = value;
                OnPropertyChanged("ResponsibleUserSelected");
            }
        }
        public List<User> ResponsibleUserList
        {
            get { return _responsibleUserList; }
            set
            {
                _responsibleUserList = value;
                OnPropertyChanged("ResponsibleUserList");
            }
        }
        public InventoryMovementMotive InventoryMovementMotiveSelected
        {
            get { return _inventoryMovementMotiveSelected; }
            set
            {
                _inventoryMovementMotiveSelected = value;
                OnPropertyChanged("InventoryMovementMotiveSelected");
            }
        }
        public List<InventoryMovementMotive> InventoryMovementMotiveList
        {
            get { return _inventoryMovementMotiveList; }
            set
            {
                _inventoryMovementMotiveList = value;
                OnPropertyChanged("InventoryMovementMotiveList");
            }
        }
        public string Comments
        {
            get { return _comments; }
            set
            {
                _comments = value;
                OnPropertyChanged("Comments");
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
        public InventoryMovement ObjInventoryMovement { get; set; }
        public List<InventoryMovementItem> InventoryMovementItemList
        {
            get { return _inventoryMovementItemList; }
            set
            {
                _inventoryMovementItemList = value;
                OnPropertyChanged("InventoryMovementItemList");
            }
        }

        #endregion

        public MIDetail()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public MIDetail(Resource objResource, object objSelected)
        {
            InitializeComponent();
            this.BindingContext = this;
            PageLoad(objResource, objSelected);
        }

        async void PageLoad(Resource objResource, object objSelected)
        {
            try
            {

                GetList();

                if (objSelected != null)
                {
                    this.ObjInventoryMovement = objSelected as InventoryMovement;

                    this.Number = this.ObjInventoryMovement.Number;
                    this.Comments = this.ObjInventoryMovement.Comments;
                    this.AdmissionDate = this.ObjInventoryMovement.AdmissionDate;
                    this.ModificationDate = this.ObjInventoryMovement.ModificationDate;

                    if (this.StateEntityList.Count > 0)
                    {
                        if (this.ObjInventoryMovement.IdStateEntity > 0)
                        {
                            StateEntity objStateEntity = this.StateEntityList.Find(x => x.IdStateEntity == this.ObjInventoryMovement.IdStateEntity);
                            if (objStateEntity != null)
                                this.StateEntitySelected = objStateEntity;
                        }
                    }
                    else
                    {
                        throw new Exception("Estado de está vacío");
                    }

                    if (this.InventoryMovementTypeList.Count > 0)
                    {
                        if (this.ObjInventoryMovement.IdInventoryMovementType > 0)
                        {
                            InventoryMovementType objInventoryMovementType = this.InventoryMovementTypeList.Find(x => x.IdInventoryMovementType == this.ObjInventoryMovement.IdInventoryMovementType);
                            if (objInventoryMovementType != null)
                                this.InventoryMovementTypeSelected = objInventoryMovementType;
                        }
                    }
                    else
                    {
                        throw new Exception("Tipo de movimiento de inventario de está vacío");
                    }

                    if (this.ResponsibleUserList.Count > 0)
                    {
                        if (this.ObjInventoryMovement.IdResponsibleUser > 0)
                        {
                            User objResponsibleUser = this.ResponsibleUserList.Find(x => x.IdUser == this.ObjInventoryMovement.IdResponsibleUser);
                            if (objResponsibleUser != null)
                                this.ResponsibleUserSelected = objResponsibleUser;
                        }
                    }
                    else
                    {
                        throw new Exception("Usuario responsable de está vacío");
                    }

                    if (this.InventoryMovementMotiveList.Count > 0)
                    {
                        if (this.ObjInventoryMovement.IdInventoryMovementMotive > 0)
                        {
                            InventoryMovementMotive objIdInventoryMovementMotive = this.InventoryMovementMotiveList.Find(x => x.IdInventoryMovementMotive == this.ObjInventoryMovement.IdInventoryMovementMotive);
                            if (objIdInventoryMovementMotive != null)
                                this.InventoryMovementMotiveSelected = objIdInventoryMovementMotive;
                        }
                    }
                    else
                    {
                        throw new Exception("Motivo del movimiento de inventario está vacío");
                    }

                    List<InventoryMovementItem> objInventoryMovementItemList = new List<InventoryMovementItem>();

                    objInventoryMovementItemList.Add(new InventoryMovementItem() 
                    {
                         IdInventoryMovementItem = 1,
                         IdItem = 1,
                         Item = new Item() 
                         {
                             IdItem = 1,
                             Name = "Labial",
                             CostPrice = 0.5m,
                             IdBrand = 1,
                             Internalcode = "A-01",
                             Unit = "Unidad"
                         },
                         Amount = 5,
                         Position = 1,
                         UnitCost = 0.5m,
                         TotalCost = 2.5m
                    });

                    objInventoryMovementItemList.Add(new InventoryMovementItem()
                    {
                        IdInventoryMovementItem = 1,
                        IdItem = 1,
                        Item = new Item()
                        {
                            IdItem = 2,
                            Name = "Base",
                            CostPrice = 0.6m,
                            IdBrand = 2,
                            Internalcode = "A-02",
                            Unit = "Unidad"
                        },
                        Amount = 8,
                        Position = 2,
                        UnitCost = 0.6m,
                        TotalCost = 2.7m
                    });

                    this.ObjInventoryMovement.InventoryMovementItemList = objInventoryMovementItemList;

                    if (this.ObjInventoryMovement.InventoryMovementItemList != null && this.ObjInventoryMovement.InventoryMovementItemList.Count > 0)
                    {
                        this.InventoryMovementItemList = this.ObjInventoryMovement.InventoryMovementItemList;
                    }
                }
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert("Ha ocurrido un error: " + exc.Message);
            }
        }

        private void GetList()
        {
            try
            {
                List<StateEntity> objStateEntityList = new List<StateEntity>();
                objStateEntityList.Add(new StateEntity(){ 
                    IdStateEntity = 1,
                    IdCompany = 1,
                    Name= "Registrado",
                });
                objStateEntityList.Add(new StateEntity()
                {
                    IdStateEntity = 2,
                    IdCompany = 1,
                    Name = "Aplicado",
                });

                this.StateEntityList = objStateEntityList;

                List<InventoryMovementType> objIMovementTypeList = new List<InventoryMovementType>();
                objIMovementTypeList.Add(new InventoryMovementType() 
                {
                    IdInventoryMovementType = 1,
                    Name = "Entrada",
                    Description = ""
                });
                objIMovementTypeList.Add(new InventoryMovementType()
                {
                    IdInventoryMovementType = 2,
                    Name = "Salida",
                    Description = ""
                });

                this.InventoryMovementTypeList = objIMovementTypeList;

                List<User> objUser = new List<User>();
                objUser.Add(new User() 
                {
                    IdUser = 1,
                    Name = "Eleazar",
                    LastName = "Saavedra",
                    IdLocal = 1,
                    Login = "esaavedrah",
                });

                this.ResponsibleUserList = objUser;

                List<InventoryMovementMotive> objIMovementMotive = new List<InventoryMovementMotive>();

                objIMovementMotive.Add(new InventoryMovementMotive() 
                {
                    IdInventoryMovementMotive = 1,
                    Name = "Venta",
                });

                objIMovementMotive.Add(new InventoryMovementMotive()
                {
                    IdInventoryMovementMotive = 2,
                    Name = "Compra",
                });

                this.InventoryMovementMotiveList = objIMovementMotive;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void btnEdit_Clicked(object sender, EventArgs e)
        {

        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {

        }

        private void btnClose_Clicked(object sender, EventArgs e)
        {

        }
    }
}