﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdHocMigrator.CategoriesService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.virtuemart.net/VM_Categories/", ConfigurationName="CategoriesService.VM_Categories")]
    public interface VM_Categories {
        
        // CODEGEN: Generating message contract since the wrapper name (GetAllCategoriesRequest) of message GetAllCategoriesRequest does not match the default value (GetAllCategories)
        [System.ServiceModel.OperationContractAttribute(Action="http://www.virtuemart.net/VM_Categories/GetAllCategories", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        AdHocMigrator.CategoriesService.GetAllCategoriesResponse GetAllCategories(AdHocMigrator.CategoriesService.GetAllCategoriesRequest request);
        
        // CODEGEN: Generating message contract since the wrapper name (GetChildsCategoriesRequest) of message GetChildsCategoriesRequest does not match the default value (GetChildsCategories)
        [System.ServiceModel.OperationContractAttribute(Action="http://www.virtuemart.net/VM_Categories/GetChildsCategories", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        AdHocMigrator.CategoriesService.GetChildsCategoriesResponse GetChildsCategories(AdHocMigrator.CategoriesService.GetChildsCategoriesRequest request);
        
        // CODEGEN: Generating message contract since the operation AddCategory is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.virtuemart.net/VM_Categories/AddCategory", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        AdHocMigrator.CategoriesService.AddCategoryResponse AddCategory(AdHocMigrator.CategoriesService.AddCategoryRequest request);
        
        // CODEGEN: Generating message contract since the operation DeleteCategory is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.virtuemart.net/VM_Categories/DeleteCategory", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        AdHocMigrator.CategoriesService.DeleteCategoryResponse DeleteCategory(AdHocMigrator.CategoriesService.DeleteCategoryRequest request);
        
        // CODEGEN: Generating message contract since the wrapper name (GetAvailableImagesRequest) of message GetAvailableImagesRequest does not match the default value (GetAvailableImages)
        [System.ServiceModel.OperationContractAttribute(Action="http://www.virtuemart.net/VM_Categories/GetAvailableImages", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        AdHocMigrator.CategoriesService.GetAvailableImagesResponse GetAvailableImages(AdHocMigrator.CategoriesService.GetAvailableImagesRequest request);
        
        // CODEGEN: Generating message contract since the operation UpdateCategory is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.virtuemart.net/VM_Categories/UpdateCategory", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        AdHocMigrator.CategoriesService.UpdateCategoryResponse UpdateCategory(AdHocMigrator.CategoriesService.UpdateCategoryRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.virtuemart.net/VM_Categories/")]
    public partial class loginInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string loginField;
        
        private string passwordField;
        
        private string langField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string login {
            get {
                return this.loginField;
            }
            set {
                this.loginField = value;
                this.RaisePropertyChanged("login");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("password");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string lang {
            get {
                return this.langField;
            }
            set {
                this.langField = value;
                this.RaisePropertyChanged("lang");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.virtuemart.net/VM_Categories/")]
    public partial class AvalaibleImage : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string image_nameField;
        
        private string image_urlField;
        
        private string realpathField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string image_name {
            get {
                return this.image_nameField;
            }
            set {
                this.image_nameField = value;
                this.RaisePropertyChanged("image_name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string image_url {
            get {
                return this.image_urlField;
            }
            set {
                this.image_urlField = value;
                this.RaisePropertyChanged("image_url");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string realpath {
            get {
                return this.realpathField;
            }
            set {
                this.realpathField = value;
                this.RaisePropertyChanged("realpath");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.virtuemart.net/VM_Categories/")]
    public partial class DeleteCategoryInput : object, System.ComponentModel.INotifyPropertyChanged {
        
        private loginInfo loginInfoField;
        
        private string category_idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public loginInfo loginInfo {
            get {
                return this.loginInfoField;
            }
            set {
                this.loginInfoField = value;
                this.RaisePropertyChanged("loginInfo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string category_id {
            get {
                return this.category_idField;
            }
            set {
                this.category_idField = value;
                this.RaisePropertyChanged("category_id");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.virtuemart.net/VM_Categories/")]
    public partial class AddCategoryInput : object, System.ComponentModel.INotifyPropertyChanged {
        
        private loginInfo loginInfoField;
        
        private Categorie categoryField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public loginInfo loginInfo {
            get {
                return this.loginInfoField;
            }
            set {
                this.loginInfoField = value;
                this.RaisePropertyChanged("loginInfo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Categorie category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
                this.RaisePropertyChanged("category");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.virtuemart.net/VM_Categories/")]
    public partial class Categorie : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string idField;
        
        private string nameField;
        
        private string descriptionField;
        
        private string parentcatField;
        
        private string imageField;
        
        private string fullimageField;
        
        private string numberofproductsField;
        
        private string category_publishField;
        
        private string category_browsepageField;
        
        private string category_flypageField;
        
        private string products_per_rowField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("id");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string parentcat {
            get {
                return this.parentcatField;
            }
            set {
                this.parentcatField = value;
                this.RaisePropertyChanged("parentcat");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string image {
            get {
                return this.imageField;
            }
            set {
                this.imageField = value;
                this.RaisePropertyChanged("image");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string fullimage {
            get {
                return this.fullimageField;
            }
            set {
                this.fullimageField = value;
                this.RaisePropertyChanged("fullimage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string numberofproducts {
            get {
                return this.numberofproductsField;
            }
            set {
                this.numberofproductsField = value;
                this.RaisePropertyChanged("numberofproducts");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string category_publish {
            get {
                return this.category_publishField;
            }
            set {
                this.category_publishField = value;
                this.RaisePropertyChanged("category_publish");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string category_browsepage {
            get {
                return this.category_browsepageField;
            }
            set {
                this.category_browsepageField = value;
                this.RaisePropertyChanged("category_browsepage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string category_flypage {
            get {
                return this.category_flypageField;
            }
            set {
                this.category_flypageField = value;
                this.RaisePropertyChanged("category_flypage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string products_per_row {
            get {
                return this.products_per_rowField;
            }
            set {
                this.products_per_rowField = value;
                this.RaisePropertyChanged("products_per_row");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAllCategoriesRequest", WrapperNamespace="http://www.virtuemart.net/VM_Categories/", IsWrapped=true)]
    public partial class GetAllCategoriesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.virtuemart.net/VM_Categories/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AdHocMigrator.CategoriesService.loginInfo loginInfo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.virtuemart.net/VM_Categories/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string category_publish;
        
        public GetAllCategoriesRequest() {
        }
        
        public GetAllCategoriesRequest(AdHocMigrator.CategoriesService.loginInfo loginInfo, string category_publish) {
            this.loginInfo = loginInfo;
            this.category_publish = category_publish;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAllCategoriesResponse", WrapperNamespace="http://www.virtuemart.net/VM_Categories/", IsWrapped=true)]
    public partial class GetAllCategoriesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.virtuemart.net/VM_Categories/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("Categorie", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Categorie[] Categorie;
        
        public GetAllCategoriesResponse() {
        }
        
        public GetAllCategoriesResponse(Categorie[] Categorie) {
            this.Categorie = Categorie;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetChildsCategoriesRequest", WrapperNamespace="http://www.virtuemart.net/VM_Categories/", IsWrapped=true)]
    public partial class GetChildsCategoriesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.virtuemart.net/VM_Categories/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AdHocMigrator.CategoriesService.loginInfo loginInfo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.virtuemart.net/VM_Categories/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string categoryId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.virtuemart.net/VM_Categories/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string category_publish;
        
        public GetChildsCategoriesRequest() {
        }
        
        public GetChildsCategoriesRequest(AdHocMigrator.CategoriesService.loginInfo loginInfo, string categoryId, string category_publish) {
            this.loginInfo = loginInfo;
            this.categoryId = categoryId;
            this.category_publish = category_publish;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetChildsCategoriesResponse", WrapperNamespace="http://www.virtuemart.net/VM_Categories/", IsWrapped=true)]
    public partial class GetChildsCategoriesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.virtuemart.net/VM_Categories/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("Categorie", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Categorie[] Categorie;
        
        public GetChildsCategoriesResponse() {
        }
        
        public GetChildsCategoriesResponse(Categorie[] Categorie) {
            this.Categorie = Categorie;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddCategoryRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddCategoryRequest", Namespace="http://www.virtuemart.net/VM_Categories/", Order=0)]
        public AdHocMigrator.CategoriesService.AddCategoryInput AddCategoryRequest1;
        
        public AddCategoryRequest() {
        }
        
        public AddCategoryRequest(AdHocMigrator.CategoriesService.AddCategoryInput AddCategoryRequest1) {
            this.AddCategoryRequest1 = AddCategoryRequest1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddCategoryResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddCategoryResponse", Namespace="http://www.virtuemart.net/VM_Categories/", Order=0)]
        public string AddCategoryResponse1;
        
        public AddCategoryResponse() {
        }
        
        public AddCategoryResponse(string AddCategoryResponse1) {
            this.AddCategoryResponse1 = AddCategoryResponse1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteCategoryRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="DeleteCategoryRequest", Namespace="http://www.virtuemart.net/VM_Categories/", Order=0)]
        public AdHocMigrator.CategoriesService.DeleteCategoryInput DeleteCategoryRequest1;
        
        public DeleteCategoryRequest() {
        }
        
        public DeleteCategoryRequest(AdHocMigrator.CategoriesService.DeleteCategoryInput DeleteCategoryRequest1) {
            this.DeleteCategoryRequest1 = DeleteCategoryRequest1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteCategoryResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="DeleteCategoryResponse", Namespace="http://www.virtuemart.net/VM_Categories/", Order=0)]
        public string DeleteCategoryResponse1;
        
        public DeleteCategoryResponse() {
        }
        
        public DeleteCategoryResponse(string DeleteCategoryResponse1) {
            this.DeleteCategoryResponse1 = DeleteCategoryResponse1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAvailableImagesRequest", WrapperNamespace="http://www.virtuemart.net/VM_Categories/", IsWrapped=true)]
    public partial class GetAvailableImagesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.virtuemart.net/VM_Categories/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AdHocMigrator.CategoriesService.loginInfo loginInfo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.virtuemart.net/VM_Categories/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string img_type;
        
        public GetAvailableImagesRequest() {
        }
        
        public GetAvailableImagesRequest(AdHocMigrator.CategoriesService.loginInfo loginInfo, string img_type) {
            this.loginInfo = loginInfo;
            this.img_type = img_type;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAvailableImagesResponse", WrapperNamespace="http://www.virtuemart.net/VM_Categories/", IsWrapped=true)]
    public partial class GetAvailableImagesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.virtuemart.net/VM_Categories/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("AvalaibleImage", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AvalaibleImage[] AvalaibleImage;
        
        public GetAvailableImagesResponse() {
        }
        
        public GetAvailableImagesResponse(AvalaibleImage[] AvalaibleImage) {
            this.AvalaibleImage = AvalaibleImage;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateCategoryRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UpdateCategoryRequest", Namespace="http://www.virtuemart.net/VM_Categories/", Order=0)]
        public AdHocMigrator.CategoriesService.AddCategoryInput UpdateCategoryRequest1;
        
        public UpdateCategoryRequest() {
        }
        
        public UpdateCategoryRequest(AdHocMigrator.CategoriesService.AddCategoryInput UpdateCategoryRequest1) {
            this.UpdateCategoryRequest1 = UpdateCategoryRequest1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateCategoryResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UpdateCategoryResponse", Namespace="http://www.virtuemart.net/VM_Categories/", Order=0)]
        public string UpdateCategoryResponse1;
        
        public UpdateCategoryResponse() {
        }
        
        public UpdateCategoryResponse(string UpdateCategoryResponse1) {
            this.UpdateCategoryResponse1 = UpdateCategoryResponse1;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface VM_CategoriesChannel : AdHocMigrator.CategoriesService.VM_Categories, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VM_CategoriesClient : System.ServiceModel.ClientBase<AdHocMigrator.CategoriesService.VM_Categories>, AdHocMigrator.CategoriesService.VM_Categories {
        
        public VM_CategoriesClient() {
        }
        
        public VM_CategoriesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VM_CategoriesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VM_CategoriesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VM_CategoriesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AdHocMigrator.CategoriesService.GetAllCategoriesResponse AdHocMigrator.CategoriesService.VM_Categories.GetAllCategories(AdHocMigrator.CategoriesService.GetAllCategoriesRequest request) {
            return base.Channel.GetAllCategories(request);
        }
        
        public Categorie[] GetAllCategories(AdHocMigrator.CategoriesService.loginInfo loginInfo, string category_publish) {
            AdHocMigrator.CategoriesService.GetAllCategoriesRequest inValue = new AdHocMigrator.CategoriesService.GetAllCategoriesRequest();
            inValue.loginInfo = loginInfo;
            inValue.category_publish = category_publish;
            AdHocMigrator.CategoriesService.GetAllCategoriesResponse retVal = ((AdHocMigrator.CategoriesService.VM_Categories)(this)).GetAllCategories(inValue);
            return retVal.Categorie;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AdHocMigrator.CategoriesService.GetChildsCategoriesResponse AdHocMigrator.CategoriesService.VM_Categories.GetChildsCategories(AdHocMigrator.CategoriesService.GetChildsCategoriesRequest request) {
            return base.Channel.GetChildsCategories(request);
        }
        
        public Categorie[] GetChildsCategories(AdHocMigrator.CategoriesService.loginInfo loginInfo, string categoryId, string category_publish) {
            AdHocMigrator.CategoriesService.GetChildsCategoriesRequest inValue = new AdHocMigrator.CategoriesService.GetChildsCategoriesRequest();
            inValue.loginInfo = loginInfo;
            inValue.categoryId = categoryId;
            inValue.category_publish = category_publish;
            AdHocMigrator.CategoriesService.GetChildsCategoriesResponse retVal = ((AdHocMigrator.CategoriesService.VM_Categories)(this)).GetChildsCategories(inValue);
            return retVal.Categorie;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AdHocMigrator.CategoriesService.AddCategoryResponse AdHocMigrator.CategoriesService.VM_Categories.AddCategory(AdHocMigrator.CategoriesService.AddCategoryRequest request) {
            return base.Channel.AddCategory(request);
        }
        
        public string AddCategory(AdHocMigrator.CategoriesService.AddCategoryInput AddCategoryRequest1) {
            AdHocMigrator.CategoriesService.AddCategoryRequest inValue = new AdHocMigrator.CategoriesService.AddCategoryRequest();
            inValue.AddCategoryRequest1 = AddCategoryRequest1;
            AdHocMigrator.CategoriesService.AddCategoryResponse retVal = ((AdHocMigrator.CategoriesService.VM_Categories)(this)).AddCategory(inValue);
            return retVal.AddCategoryResponse1;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AdHocMigrator.CategoriesService.DeleteCategoryResponse AdHocMigrator.CategoriesService.VM_Categories.DeleteCategory(AdHocMigrator.CategoriesService.DeleteCategoryRequest request) {
            return base.Channel.DeleteCategory(request);
        }
        
        public string DeleteCategory(AdHocMigrator.CategoriesService.DeleteCategoryInput DeleteCategoryRequest1) {
            AdHocMigrator.CategoriesService.DeleteCategoryRequest inValue = new AdHocMigrator.CategoriesService.DeleteCategoryRequest();
            inValue.DeleteCategoryRequest1 = DeleteCategoryRequest1;
            AdHocMigrator.CategoriesService.DeleteCategoryResponse retVal = ((AdHocMigrator.CategoriesService.VM_Categories)(this)).DeleteCategory(inValue);
            return retVal.DeleteCategoryResponse1;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AdHocMigrator.CategoriesService.GetAvailableImagesResponse AdHocMigrator.CategoriesService.VM_Categories.GetAvailableImages(AdHocMigrator.CategoriesService.GetAvailableImagesRequest request) {
            return base.Channel.GetAvailableImages(request);
        }
        
        public AvalaibleImage[] GetAvailableImages(AdHocMigrator.CategoriesService.loginInfo loginInfo, string img_type) {
            AdHocMigrator.CategoriesService.GetAvailableImagesRequest inValue = new AdHocMigrator.CategoriesService.GetAvailableImagesRequest();
            inValue.loginInfo = loginInfo;
            inValue.img_type = img_type;
            AdHocMigrator.CategoriesService.GetAvailableImagesResponse retVal = ((AdHocMigrator.CategoriesService.VM_Categories)(this)).GetAvailableImages(inValue);
            return retVal.AvalaibleImage;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AdHocMigrator.CategoriesService.UpdateCategoryResponse AdHocMigrator.CategoriesService.VM_Categories.UpdateCategory(AdHocMigrator.CategoriesService.UpdateCategoryRequest request) {
            return base.Channel.UpdateCategory(request);
        }
        
        public string UpdateCategory(AdHocMigrator.CategoriesService.AddCategoryInput UpdateCategoryRequest1) {
            AdHocMigrator.CategoriesService.UpdateCategoryRequest inValue = new AdHocMigrator.CategoriesService.UpdateCategoryRequest();
            inValue.UpdateCategoryRequest1 = UpdateCategoryRequest1;
            AdHocMigrator.CategoriesService.UpdateCategoryResponse retVal = ((AdHocMigrator.CategoriesService.VM_Categories)(this)).UpdateCategory(inValue);
            return retVal.UpdateCategoryResponse1;
        }
    }
}