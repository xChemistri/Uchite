public interface Translatable
{
	public string RuStr ();
	public string EnStr ();
	public Translatable Next ();
	public bool HasNext ();

	public bool IsForm (string word);
	public string IsFormDetailed (string word);
}