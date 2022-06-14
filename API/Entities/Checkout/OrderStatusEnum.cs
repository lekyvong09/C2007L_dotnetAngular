using System;
using System.Runtime.Serialization;

namespace API.Entities.Checkout
{
	public enum OrderStatusEnum
	{
        [EnumMember(Value = "Pending")]
        Pending,

        [EnumMember(Value = "Payment Received")]
        PaymentReceived,

        [EnumMember(Value = "Payment Failed")]
        PaymentFailed
    }
}

