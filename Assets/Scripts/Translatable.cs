public interface Translatable
{
	public string RuStr ();
	public string EnStr ();
	public Translatable Next ();
	
	public bool CaseGroup ();
	public string WhatCaseGroup ();
//	public bool Belongs (string word);
//	public string GetType (string word);
}