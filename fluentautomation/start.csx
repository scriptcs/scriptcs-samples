var Test = Require<F14N>()
	.Init<FluentAutomation.SeleniumWebDriver>()
	.Bootstrap("Chrome")
	.Config(settings => {
		settings.DefaultWaitUntilTimeout = TimeSpan.FromSeconds(1);
	});

Test.Run("KnockoutJS Cart Editor", I => {
	I.Open("http://knockoutjs.com/examples/cartEditor.html");
	I.Select("Motorcycles").From(".liveExample tr select:eq(0)"); // Select by value/text
	I.Select(2).From(".liveExample tr select:eq(1)"); // Select by index
	I.Enter(6).In(".liveExample td.quantity input:eq(0)");
	I.Expect.Text("$197.70").In(".liveExample tr span:eq(1)");

	// add second product
	I.Click(".liveExample button:eq(0)");
	I.Select(1).From(".liveExample tr select:eq(2)");
	I.Select(4).From(".liveExample tr select:eq(3)");
	I.Enter(8).In(".liveExample td.quantity input:eq(1)");
	I.Expect.Text("$788.64").In(".liveExample tr span:eq(3)");

	// validate totals
	I.Expect.Text("$986.34").In("p.grandTotal span");

	// remove first product
	I.Click(".liveExample a:eq(0)");

	// validate new total
	I.WaitUntil(() => I.Expect.Text("$788.64").In("p.grandTotal span"));
});

Test.Run("YUI Drag and Drop", I => {
	I.Open("http://automation.apphb.com/interactive");

	// wait for page to render properly
	I.Wait(TimeSpan.FromMilliseconds(500));
	I.Drag("#pt1").To("#t2");
	I.Drag("#pt2").To("#t1");
	I.Drag("#pb1").To("#b1");
	I.Drag("#pb2").To("#b2");
	I.Drag("#pboth1").To("#b3");
	I.Drag("#pboth2").To("#b4");
	I.Drag("#pt1").To("#pt2");
	I.Drag("#pboth1").To("#pb2");
});