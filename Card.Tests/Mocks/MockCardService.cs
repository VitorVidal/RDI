using Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card.Tests.Mocks
{
    public class MockCardService:Mock<ICardService>
    {
        public MockCardService MockSave(Card card)
        {
            Setup(x => x.Save(card)).Returns(card);
            return this;
        }
    }
}
