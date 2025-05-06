using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public IResult Add(Order Order)
        {
            _orderDal.Add(Order);
            return new SuccessResult("Sipariş oluşturuldu");

        }

        public IResult Delete(int orderId)
        {
            var order = _orderDal.Get(o => o.OrderId == orderId);
            if (order == null) return new ErrorResult("Sipariş bulunamadı");
            _orderDal.Delete(order);
            return new SuccessResult("Sipariş silindi");
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }

        public IResult Update(Order Order)
        {
            _orderDal.Update(Order);
            return new SuccessResult("Sipariş güncellendi");
        }
    }
}
