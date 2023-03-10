import pandas as pd
import pyodbc
import sqlalchemy

def df_userstory2(path):
    df = pd.read_csv(path, sep=";")

    df.columns = df.columns.str.upper()

    for col in df.columns[1:]:
        if col in df.columns[-3:]:
            df[col] = pd.to_datetime(df[col], errors="coerce")
        else:
            df[col] = df[col].str.upper()

    return df

def create_table(server,
                 database,
                 user,
                 pwd,
                 df,
                 name_table):

    engine = sqlalchemy.create_engine(
        "mssql+pyodbc:///?odbc_connect="
        "DRIVER= {SQL Server};"
        f"SERVER={server};"
        f"DATABASE={database};"
        f"UID={user};"
        f"PWD={pwd};"
    )
    df.to_sql(name_table, con=engine, if_exists='replace')
    engine.dispose()
    
    print("Pushed table")

create_table(server = 'ta5.cs9naymhw4no.ap-southeast-2.rds.amazonaws.com;',
             database = 'ONBOARDING',
             user = 'fit5120ta5',
             pwd = 'ta5workmail123',
             df = df_userstory2("us_2_2.csv"),
             name_table = 'US_2_2')

# testing ----

sql_parameters = ('DRIVER={SQL Server};' +
                  'SERVER=ta5.cs9naymhw4no.ap-southeast-2.rds.amazonaws.com;' +
                  'DATABASE=ONBOARDING;' +
                  'UID=fit5120ta5;' +
                  'PWD=ta5workmail123;' +
                  'PORT=1433')

sql_connection = pyodbc.connect(sql_parameters)
df = pd.read_sql("SELECT * FROM US_2_2", sql_connection)
sql_connection.close()
# df.dtypes
# df.to_csv("kk.csv")









