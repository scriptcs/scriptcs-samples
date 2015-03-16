using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

var data = (from nodes in XElement.Load("schema.xml").Descendants()
	    select new
	    {
		Name = nodes.Attributes("name"),
		Ref = nodes.Attributes("ref")
            });

var list = new List<string>();

foreach (var item in data)
{
	if (item.Name.FirstOrDefault() != null) list.Add(item.Name.FirstOrDefault().Value);
	if (item.Ref.FirstOrDefault() != null) list.Add(item.Ref.FirstOrDefault().Value);
}

foreach (var item in list.Distinct().OrderBy(i => i.ToString())) {
	Console.WriteLine(item);
}
