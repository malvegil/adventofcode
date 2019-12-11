<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var input = @"Al => ThF
Al => ThRnFAr
B => BCa
B => TiB
B => TiRnFAr
Ca => CaCa
Ca => PB
Ca => PRnFAr
Ca => SiRnFYFAr
Ca => SiRnMgAr
Ca => SiTh
F => CaF
F => PMg
F => SiAl
H => CRnAlAr
H => CRnFYFYFAr
H => CRnFYMgAr
H => CRnMgYFAr
H => HCa
H => NRnFYFAr
H => NRnMgAr
H => NTh
H => OB
H => ORnFAr
Mg => BF
Mg => TiMg
N => CRnFAr
N => HSi
O => CRnFYFAr
O => CRnMgAr
O => HP
O => NRnFAr
O => OTi
P => CaP
P => PTi
P => SiRnFAr
Si => CaSi
Th => ThCa
Ti => BP
Ti => TiTi
e => HF
e => NAl
e => OMg

CRnCaCaCaSiRnBPTiMgArSiRnSiRnMgArSiRnCaFArTiTiBSiThFYCaFArCaCaSiThCaPBSiThSiThCaCaPTiRnPBSiThRnFArArCaCaSiThCaSiThSiRnMgArCaPTiBPRnFArSiThCaSiRnFArBCaSiRnCaPRnFArPMgYCaFArCaPTiTiTiBPBSiThCaPTiBPBSiRnFArBPBSiRnCaFArBPRnSiRnFArRnSiRnBFArCaFArCaCaCaSiThSiThCaCaPBPTiTiRnFArCaPTiBSiAlArPBCaCaCaCaCaSiRnMgArCaSiThFArThCaSiThCaSiRnCaFYCaSiRnFYFArFArCaSiRnFYFArCaSiRnBPMgArSiThPRnFArCaSiRnFArTiRnSiRnFYFArCaSiRnBFArCaSiRnTiMgArSiThCaSiThCaFArPRnFArSiRnFArTiTiTiTiBCaCaSiRnCaCaFYFArSiThCaPTiBPTiBCaSiThSiRnMgArCaF";

	var data = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
	var molecule = data.Last();
	var replacements = data.Where(x => x.Contains("=>")).Select(x => x.Split()).Select(x => new { start = x[0], change = x[2] }).ToList();
	
	//part 1
	var new_molecules = new List<string>();

	foreach (var r in replacements)
	{
		foreach (Match m in Regex.Matches(molecule, r.start, RegexOptions.Compiled))
		{
			var new_molecule = molecule.Remove(m.Index, r.start.Length).Insert(m.Index, r.change);
			new_molecules.Add(new_molecule);
		}
	}
	
	new_molecules.Distinct().ToList().Count.Dump();

	//part 2
	var step_count = 0;
	while (molecule != "e")
	{
		for (var x = 1; x < replacements.Count; x++)
		{
			if (molecule.Contains(replacements[x].change))
            {
				var r = new Regex(replacements[x].change);
				molecule = r.Replace(molecule, replacements[x].start, 1);
				step_count++;
			}
		}
	}
	
	step_count.Dump();
}

// Define other methods and classes here