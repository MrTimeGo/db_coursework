psql --command "UPDATE pg_database SET datallowconn = 'false' WHERE datname = 'university'" "host=localhost port=5432 user=postgres password=Artik2003"
psql --command "SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname = 'university'" "host=localhost port=5432 user=postgres password=Artik2003"
psql --command "DROP DATABASE university" "host=localhost port=5432 user=postgres password=Artik2003"
psql --command "CREATE DATABASE university" "host=localhost port=5432 user=postgres password=Artik2003"
psql -f %1 "host=localhost port=5432 dbname=university user=postgres password=Artik2003"