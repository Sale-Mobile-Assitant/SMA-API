using RestAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class ModelFactory
    {
        public CompanyModel Create(Company _company)
        {
            return new CompanyModel()
            {
                CompID = _company.CompID,
                CompName = _company.CompName,
                Address1 = _company.Address1,
                Address2 = _company.Address2,
                Address3 = _company.Address3,
                City = _company.City,
                PhoneNum = _company.PhoneNum,
                Province = _company.Province,
                EmployeeType = _company.EmployeeTypes.Select(e => Create(e)),
                ProductGroup = _company.ProductGroups.Select(p => Create(p)),
                Site = _company.Sites.Select(s => Create(s))
            };
        }
        public SiteModel Create(Site _site)
        {
            return new SiteModel()
            {
                CompID = _site.CompID,
                SiteID = _site.SiteID,
                SiteName = _site.SiteName,
                Address1 = _site.Address1,
                Address2 = _site.Address2,
                Address3 = _site.Address3,
                City = _site.City,
                Province = _site.Province,
                PhoneNum = _site.PhoneNum,
                ProductInSites = _site.ProductInSites.Select(p => Create(p))
            };
        }
        public EmployeeTypeModel Create(EmployeeType _employeeType)
        {
            return new EmployeeTypeModel()
            {
                CompID = _employeeType.CompID,
                ETypeID = _employeeType.ETypeID,
                ETypeDescription = _employeeType.ETypeDescription,
                Commissionable = _employeeType.Commissionable,
                Employees = _employeeType.Employees.Select(e => Create(e))
            };
        }
        public EmployeeModel Create(Employee _employee)
        {
            return new EmployeeModel()
            {
                CompID = _employee.CompID,
                ETypeID = _employee.ETypeID,
                EmplID = _employee.EmplID,
                EmplName = _employee.EmplName,
                Address1 = _employee.Address1,
                Address2 = _employee.Address2,
                Address3 = _employee.Address3,
                PhoneNum = _employee.PhoneNum,
                DateIn = _employee.DateIn,
                DateOut = _employee.DateOut,
                Account = _employee.Accounts.Select(a => Create(a)),
                Customer = _employee.Customers.Select(c => Create(c)),
                Order = _employee.Orders.Select(o => Create(o)),
                RoutePlan = _employee.RoutePlans.Select(r => Create(r)),
                SaleTarget = _employee.SaleTargets.Select(s => Create(s)),
            };
        }
        public AccountModel Create(Account _account)
        {
            return new AccountModel()
            {
                CompID = _account.CompID,
                ID = _account.ID,
                Username = _account.Username,
                Password = _account.Password,
                Type = _account.Type,
                EmplID = _account.EmplID,
                Note = _account.Note,
            };
        }
        public CustomerModel Create(Customer _customer)
        {
            return new CustomerModel()
            {
                CompID = _customer.CompID,
                EmplID = _customer.EmplID,
                CustID = _customer.CustID.ToString(),
                CustName = _customer.CustName,
                Address1 = _customer.Address1,
                Address2 = _customer.Address2,
                Address3 = _customer.Address3,
                City = _customer.City,
                Country = _customer.Country,
                PhoneNum = _customer.PhoneNum,
                Discount = _customer.Discount.ToString(),
                Order = _customer.Orders.Select(o => Create(o)),
            };
        }
        public OrderModel Create(Order _order)
        {
            return new OrderModel()
            {
                CompID = _order.CompID,
                MyOrderID = _order.MyOrderID,
                OrdeID = _order.OrdeID,
                CustID = _order.CustID,
                EmplID = _order.EmplID,
                OrderDate = _order.OrderDate,
                NeedByDate = _order.NeedByDate,
                RequestDate = _order.RequestDate,
                OrderStatus = _order.OrderStatus,
                OrderDetail = _order.OrderDetails.Select(o => Create(o))                 
            };
        }
        public OrderDetailModel Create(OrderDetail _orderDetail)
        {
            return new OrderDetailModel()
            {
                CompID = _orderDetail.CompID,
                SiteID = _orderDetail.SiteID,
                MyOrderID = _orderDetail.MyOrderID,
                ProdID = _orderDetail.ProdID,
                SellingQuantity = _orderDetail.SellingQuantity,
                UnitPrice = _orderDetail.UnitPrice,
                LineType = _orderDetail.LineType,
                OrderLine = _orderDetail.OrderLine,
                OrderNum = _orderDetail.OrderNum
            };
        }
        public RoutePlanModel Create(RoutePlan _routePlan)
        {
            return new RoutePlanModel()
            {
                CompID = _routePlan.CompID,
                EmplID = _routePlan.EmplID,
                CustID = _routePlan.CustID,
                DatePlan = _routePlan.DatePlan,
                Prioritize = _routePlan.Prioritize,
                Visited = _routePlan.Visited,
                Note = _routePlan.Note,
            };
        }
        public SaleTargetModel Create(SaleTarget _saleTarget)
        {
            return new SaleTargetModel()
            {
                CompID = _saleTarget.CompID,
                ID = _saleTarget.ID,
                EmplID = _saleTarget.EmplID,
                PeriodTarget = _saleTarget.PeriodTarget,
                YearTarget = _saleTarget.YearTarget,
                TargetQty = _saleTarget.TargetQty,
                Note = _saleTarget.Note,
            };
        }
        public ProductGroupModel Create(ProductGroup _productGroup)
        {
            return new ProductGroupModel()
            {
                CompID = _productGroup.CompID,
                PGroupID = _productGroup.PGroupID,
                PGdescription = _productGroup.PGdescription,
                Products = _productGroup.Products.Select(p => Create(p))
            };
        }
        public ProductModel Create(Product _product)
        {
            return new ProductModel()
            {
                CompID = _product.CompID,
                PGroupID = _product.PGroupID,
                ProdID = _product.ProdID,
                ProdName = _product.ProdName,
                UnitPrice = _product.UnitPrice,
                UOM = _product.UOM,
                DateUpdate = _product.DateUpdate,
                ProductInSites = _product.ProductInSites.Select(p => Create(p))
            };
        }
        public ProductInSiteModel Create(ProductInSite _productInSite)
        {
            return new ProductInSiteModel()
            {
                CompID = _productInSite.CompID,
                SiteID = _productInSite.SiteID,
                ProdID = _productInSite.ProdID,
                Quantity = _productInSite.Quatity,
                UOM = _productInSite.UOM,
                OrderDetails = _productInSite.OrderDetails.Select(o => Create(o))
            };
        }
    }
}