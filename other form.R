library(DBI)
library(odbc)

#Establish connection
con <- DBI::dbConnect(drv = odbc::odbc(), #driver
                      driver = "SQL Server", #The ODBC driver name
                      server = "ta5.cs9naymhw4no.ap-southeast-2.rds.amazonaws.com",
                      database = "ONBOARDING", #Database of the server
                      uid = "fit5120ta5", #user stablished in SQL Server
                      pwd = "ta5workmail123", #password stablished in SQL Server
                      port = 1433) 

dfs <- map(str_glue("C:/Users/actje/Dropbox/PERSONAL/MONASH/DATA SCIENCE/3 SEMESTER/FIT5120-INDUSTRY EXPERIENCE/ASS_ONBOARDING/UTILS/FIT5120_Onboarding/{c('MAIN', 'POST_CODE', 'STREET')}.csv"),
           ~ fread(.x))

map2(c("Schedules","PostCode", "Address"),
     dfs,
     ~ dbWriteTable(conn = con,
                    name = .x,
                    value = .y,
                    overwrite = TRUE)
)