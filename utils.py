
import pandas as pd
# import nltk
# nltk.download('stopwords')
from nltk.corpus import stopwords
from nltk.tokenize import word_tokenize
import pyodbc
import sqlalchemy


def df_userstory1(path):

    df = pd.read_excel(path)
    df = df.iloc[:, 1:]
    df.columns = df.columns.str.upper()

    for col in df.columns:
        df[col] = df[col].str.replace(r"[^a-zA-Z0-9\s]+", "")
        df[col] = df[col].str.upper()

    df.iloc[:, -1] = df.iloc[:, -1].str.cat(["."]*len(df), sep="")

    stablish_stopwords = set(word.upper()
                             for word in stopwords.words('english'))

    id_colour = df.iloc[:, -1]
    id_colour = id_colour.apply(
        lambda tokenization: word_tokenize(tokenization))

    id_colour = id_colour.apply(lambda stopwords: [
        token for token in stopwords if token not in stablish_stopwords])

    colour = []

    for i in id_colour:
        if any(word in i for word in ["LANDFILL", "TOYS", "BICYCLE", "PLASTICS", "BATTERIES", "BOTTLES",
                                      "EWASTE", "CHEMICALS", "CHEMICAL", "CLOTHING", "METAL",
                                      "KITCHENWARE", "MEDICINES", "OIL", "OILS", "PAINT", "GLASS"]):
            colour.append("RED")
        elif any(word in i for word in ["GARDENGREEN", "HARD", "HARDWASTE", "GARDEN"]):
            colour.append("GREEN")
        elif "YELLOW" in i:
            colour.append("YELLOW")
        else:
            colour.append("YELLOW")

    df["COLOR"] = colour

    return df


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
    df.to_sql(name_table, con=engine, if_exists='replace', index=False)
    engine.dispose()

    print("Pushed table")


list(map(lambda df, name:
         create_table(server='ta5.cs9naymhw4no.ap-southeast-2.rds.amazonaws.com;',
                      database='ONBOARDING',
                      user='fit5120ta5',
                      pwd='ta5workmail123',
                      df=df,
                      name_table=name),
         [df_userstory1("us_2_1.xlsx"), df_userstory2("us_2_2.csv")],
         ["US_2_1", "US_2_2"]
         ))


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
