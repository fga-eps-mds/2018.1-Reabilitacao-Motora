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

    //replace("Instantiations/Patient/DeletePatientButton.cs");
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

    string strTemp1, strTemp2, strTemp3;
    int j = 0, i = 0;

    while(getline(filein, strTemp1))
    {
        fileout << strTemp1 << endl;
        if(strTemp1.find("else") != -1 || strTemp1.find("class") != -1 || strTemp1.find("public") != -1 || strTemp1.find("get") != -1 || strTemp1.find("set") != -1
           || strTemp1.find("for") != -1 || strTemp1.find("if") != -1 || strTemp1.find("while") != -1 || strTemp1.find("namespace") != -1)
        {
            getline(filein, strTemp2);
            getline(filein, strTemp3);


            if ((strTemp3.find("{") != - 1) && (  strTemp2.length() == ( (count(strTemp2.begin(), strTemp2.end(), '\t')) + (count(strTemp2.begin(), strTemp2.end(), ' ')) 
            + (count(strTemp2.begin(), strTemp2.end(), '\r'))) )  )
            {
            }
            else
            {
                fileout << strTemp2 << endl;
            }
           

            fileout << strTemp3 << endl;
        }
        
    }
    rename ("temp.txt", path.c_str());
}