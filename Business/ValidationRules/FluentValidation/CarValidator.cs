using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(2); // buradaki 'c'; yukarıda bulunan <Car> içindeki 'Car'a karşılık gelir.
            RuleFor(c => c.DailyPrice).GreaterThan(0); // DailyPrice 0'dan büyük olmalı
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(500).When(c => c.BrandId == 5);
            RuleFor(c => c.Description).Must(StartWithA).WithMessage("Arabalar A harfi ile başlamalıdır"); // 'Must' true yada false döner. True dönerse çalışır. False dönerse patlar

        }

        // bu true yada false döner. True dönerse çalışır. False dönerse patlar
        private bool StartWithA(string arg) // buradaki 'arg' yukarıda 4. kuraldaki c.Description'a karşılık gelir
        {
            return arg.StartsWith("A");
        }
    }
}
