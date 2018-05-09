#include <bits/stdc++.h>
#include <experimental/filesystem>

using namespace std;

namespace fs = std::experimental::filesystem;


vector<string> listFiles (string path, string extension)
{
	vector<string> x;
	for(auto& p: fs::recursive_directory_iterator(path))
	{
		if(p.path().extension() == extension)
		{
			x.push_back(p.path().string());
		}
	}

	return x;
}


void replace(string path);

int main () {
	vector<fs::path> ret;
	fs::path root;
	string ext;
	vector<string> x = listFiles(".", ".cs");
	for (auto & v : x)
		replace(v.substr(2));
	return 0;
}


void replace (string path)
{
    ifstream filein(path);
    ofstream fileout("temp.txt"); //Temporary file
   
    if(!filein || !fileout)
    {
        cout << "Error opening files!" << endl;
        return;
    }

    string strTemp;
    int j = 0, i = 0;

    while(getline(filein, strTemp))
    {
    	int posx = strTemp.find(" {"), posy = strTemp.find(" { "), posz = strTemp.find("{"), posw = strTemp.find("{ ");
    	string temp = "<>";
    	if (posx != -1 && strTemp.length() == (posx+3)) {
    		size_t ntabs = count(strTemp.begin(), strTemp.end(), '\t');
    		string ident = string(ntabs, '\t');
    		strTemp.pop_back();
    		strTemp.pop_back();
    		strTemp.pop_back();
    		temp = ident + "{";
    	}

    	else if (posy != -1 && strTemp.length() == (posy+4)) {

    		size_t ntabs = count(strTemp.begin(), strTemp.end(), '\t');
    		string ident = string(ntabs, '\t');
			strTemp.pop_back();
			strTemp.pop_back();
			strTemp.pop_back();
			strTemp.pop_back();
			temp = ident + "{";
		}

    	else if (posz != -1 && strTemp.length() == (posz+2)) {

    		size_t ntabs = count(strTemp.begin(), strTemp.end(), '\t');
    		string ident = string(ntabs, '\t');

			strTemp.pop_back();
			strTemp.pop_back();
			
			temp = ident + "{";
		}

    	else if (posw != -1 && strTemp.length() == (posw+3)) {

    		size_t ntabs = count(strTemp.begin(), strTemp.end(), '\t');
    		string ident = string(ntabs, '\t');
			
			strTemp.pop_back();
			strTemp.pop_back();
			strTemp.pop_back();
			temp = ident + "{";
		}

    	fileout << strTemp << '\n';
    	if (temp != "<>") {
    		fileout << temp << '\n';  
    	}
    }

    rename ("temp.txt", path.c_str());

}