using Machine.Specifications;
using Xunit;

namespace Sut.Specs {

  // original source: https://github.com/kfinley/Platform8/blob/main/dotnet/Tests.Common/Specs/SpecBase.cs
  public abstract class SpecBase : IClassFixture<MSpecFixture> {
    private object lockObject = new object();

    protected MSpecFixture Fixture;

    public SpecBase(MSpecFixture fixture) {
      Fixture = fixture;
    }

    protected void Setup(IClassFixture<MSpecFixture> spec, Establish context, Because of) {
      lock (lockObject)
        Fixture.Setup(spec, context, of);
    }
  }

  public abstract class SpecBase<TRequest, TResponse> : SpecBase {
    protected static TRequest Request;
    protected static TResponse Result;

    public SpecBase(MSpecFixture fixture) : base(fixture) {
    }
  }
}
