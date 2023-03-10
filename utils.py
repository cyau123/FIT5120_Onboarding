import pandas as pd

def df_userstory2(path):
    df = pd.read_csv(path, sep = ";")

    df.columns = df.columns.str.upper()
    
    for col in df.columns[1:]:
        if col in df.columns[-3:]:
            df[col] = pd.to_datetime(df[col], errors= "coerce")
        else:
            df[col] = df[col].str.upper()

    return df


# df = df_userstory2("us_2_2.csv")
# df.dtypes
# df.to_csv("kk.csv")